using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsFormsApplication1.View;

namespace WindowsFormsApplication1
{
    public static class Program
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var homeScreen = new programMainForm("homeScreen");
            //create home screen for application


            Application.Run(homeScreen);
        }
    }
}