using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
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

        private static void Update()
        {
            m_routines.RemoveAll(r => !r.MoveNext());
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
            var dialog = new SaveFileDialog();
            dialog.DefaultExt = "mp4";
            dialog.Filter = "Videos|*.mp4";
            dialog.AddExtension = true;
            if (dialog.ShowDialog() != DialogResult.OK)
                yield break;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            while (watch.ElapsedMilliseconds < 100)
                yield return null;

            var path = dialog.FileName; // Path.ChangeExtension(dialog.FileName, "gif");
            var panel = m_mainWindow.m_imagePanel;

            var scalingFactor = GetScalingFactor();
            Func<int, int> Scale = i => (int) (i * scalingFactor);

            // must be multiples of 2
            var size = panel.ClientRectangle.Size;
            size.Height -= m_mainWindow.m_recordButton.Height;
            var bmp = new Bitmap(Scale(size.Width) / 2 * 2, Scale(size.Height) / 2 * 2);
            var screenPt = panel.PointToScreen(Point.Empty);

            var totalWatch = System.Diagnostics.Stopwatch.StartNew();
            using (var encoder = new Accord.Video.FFMPEG.VideoFileWriter())
            {
                encoder.Open(path, bmp.Size.Width, bmp.Size.Height, 30, Accord.Video.FFMPEG.VideoCodec.H264);

                do
                {
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.CopyFromScreen(
                            Scale(screenPt.X),
                            Scale(screenPt.Y),
                            0, 0,
                            bmp.Size,
                            CopyPixelOperation.SourceCopy);
                    }
                    encoder.WriteVideoFrame(bmp, totalWatch.Elapsed);

                    watch = System.Diagnostics.Stopwatch.StartNew();
                    while (watch.Elapsed.TotalSeconds < 1.0 / encoder.FrameRate)
                        yield return null;
                } while (!m_stopRecording);

                encoder.Close();
            }
        }
    }
}
