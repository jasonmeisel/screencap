using System;
using System.Collections.Generic;
using System.Drawing;
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
            UpdateBitmap(m_mainWindow);
        }

        private static void UpdateBitmap(MainWindow mainWindow)
        {
            var panel = mainWindow.ImagePanel;

            var bmp = panel.BackgroundImage;
            if (bmp == null)
            {
                bmp = panel.BackgroundImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            }

            var screenPt = panel.PointToScreen(Point.Empty);

            m_mainWindow.AllowTransparency = true;
            m_mainWindow.Opacity = 0.5f;
            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(
                    screenPt.X,
                    screenPt.Y,
                    0, 0,
                    panel.Bounds.Size,
                    CopyPixelOperation.SourceCopy);
            }

            panel.Invalidate();
        }
    }
}
