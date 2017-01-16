using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;

namespace screencap
{
    static class Program
    {
        private static MainWindow m_mainWindow;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Idle += Application_Idle;

            m_mainWindow = new MainWindow();
            m_mainWindow.TopMost = true;
            m_mainWindow.AutoScaleMode = AutoScaleMode.Dpi;
            m_mainWindow.m_recordButton.Click += OnRecordButtonClicked;
            Application.Run(m_mainWindow);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Message
        {
            public IntPtr hWnd;
            public int msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public Point p;
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [SuppressUnmanagedCodeSecurity, DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

        // http://stackoverflow.com/questions/5977445/how-to-get-windows-display-settings
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,

            // http://pinvoke.net/default.aspx/gdi32/GetDeviceCaps.html
        }


        public static float GetScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int) DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int) DeviceCap.DESKTOPVERTRES);

            float ScreenScalingFactor = (float) PhysicalScreenHeight / (float) LogicalScreenHeight;

            return ScreenScalingFactor; // 1.25 = 125%
        }

        static List<IEnumerator> m_routines = new List<IEnumerator>();
        public static void StartRoutine(IEnumerator routine)
        {
            m_routines.Add(routine);
        }

        private static void Application_Idle(object sender, EventArgs e)
        {
            Message message;
            while (!PeekMessage(out message, IntPtr.Zero, 0, 0, 0))
            {
                Update();
            }
        }

        static bool MoveNextRecursive(IEnumerator routine)
        {
            if (routine.Current is IEnumerator && MoveNextRecursive((IEnumerator) routine.Current))
            {
                return true;
            }
            return routine.MoveNext();
        }

        public static IEnumerator WaitForSeconds(double seconds)
        {
            var watch = Stopwatch.StartNew();
            while (watch.Elapsed.TotalSeconds < seconds)
                yield return null;
        }

        private static void Update()
        {
            m_routines.RemoveAll(r => !MoveNextRecursive(r));
        }

        static bool m_stopRecording = true;
        private static void OnRecordButtonClicked(object sender, EventArgs e)
        {
            m_stopRecording = !m_stopRecording;
            ((Button) sender).Text = m_stopRecording ? "Record" : "Stop";
            if (!m_stopRecording)
                StartRoutine(RecordGif());
        }

        private static IEnumerator RecordGif()
        {
            var path = RunSaveFileDialog();
            if (path == null)
                yield break;

            var oldBackColor = m_mainWindow.m_statusLabel.BackColor;
            yield return DoCountdown();

            var scalingFactor = GetScalingFactor();
            Func<int, int> Scale = i => (int) (i * scalingFactor);

            var fps = GetFPS();

            var panel = m_mainWindow.m_imagePanel;
            var bmp = CreateBitmap(panel, Scale);
            var screenPt = panel.PointToScreen(Point.Empty);
            var secsPerFrame = 1.0 / fps;

            var totalWatch = Stopwatch.StartNew();
            using (var encoder = new Accord.Video.FFMPEG.VideoFileWriter())
            {
                encoder.Open(path, bmp.Size.Width, bmp.Size.Height, fps, Accord.Video.FFMPEG.VideoCodec.H264);

                var thisFrameWatch = new Stopwatch();
                do
                {
                    thisFrameWatch.Restart();
                    CopyScreenToBitmap(bmp, Scale(screenPt.X) + 1, Scale(screenPt.Y) + 1);
                    encoder.WriteVideoFrame(bmp, totalWatch.Elapsed);
                    yield return WaitForSeconds(secsPerFrame - thisFrameWatch.Elapsed.TotalSeconds);
                } while (!m_stopRecording);

                encoder.Close();
            }

            m_mainWindow.m_statusLabel.BackColor = oldBackColor;
            m_mainWindow.m_statusLabel.Text = "";

            if (m_mainWindow.m_showExplorerCheckbox.Checked)
            {
                Process.Start("explorer", $"/select,\"{path}\"");
            }

            if (m_mainWindow.m_closeAfterCheckbox.Checked)
            {
                Application.Exit();
            }
        }

        private static string RunSaveFileDialog()
        {
            var dialog = new SaveFileDialog();
            dialog.DefaultExt = "mp4";
            dialog.Filter = "Videos|*.mp4";
            dialog.AddExtension = true;
            var dialogResult = dialog.ShowDialog();
            var path = dialogResult == DialogResult.OK ? dialog.FileName : null;
            return path;
        }

        private static void CopyScreenToBitmap(Bitmap bmp, int sourceX, int sourceY)
        {
            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(sourceX, sourceY, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            }
        }

        private static int GetFPS()
        {
            int fps = int.TryParse(m_mainWindow.m_fpsBox.Text, out fps) ? fps : 30;
            m_mainWindow.m_fpsBox.Text = fps.ToString();
            return fps;
        }

        private static IEnumerator DoCountdown()
        {
            for (int i = 3; i > 0; --i)
            {
                m_mainWindow.m_statusLabel.Text = $"{i}...";
                yield return WaitForSeconds(1);
            }
            m_mainWindow.m_statusLabel.Text = "Recording!";
            m_mainWindow.m_statusLabel.BackColor = Color.Red;
        }

        private static Bitmap CreateBitmap(Panel panel, Func<int, int> Scale)
        {
            // must be multiples of 2
            var size = panel.ClientRectangle.Size;
            var width = Scale(size.Width);
            width -= width % 2 + 2;
            var height = Scale(size.Height);
            height -= height % 2 + 2;
            var bmp = new Bitmap(width, height);
            return bmp;
        }
    }
}
