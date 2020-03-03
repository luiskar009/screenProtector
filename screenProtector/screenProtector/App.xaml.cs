using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Threading;


namespace screenProtector
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    /// 

    
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            List<string> images = Directory.EnumerateFiles(ConfigurationManager.AppSettings["path"], "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg")).ToList();

            getImagesUpFront(images[1]);

            // Cierra la aplicacion
            Environment.Exit(0);
        }

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, uint windowStyle);

        public static void getOutlookUpFront()
        {
            Process process = Process.GetProcessesByName("outlook")[0];

            if (process != null)
            {
                IntPtr s = process.MainWindowHandle;
                ShowWindow(s, 1);
            }
        }

        public static void getImagesUpFront(string path)
        {
            PictureBox pb = new PictureBox(path);
            pb.Show();
            Thread.Sleep(3000);
            pb.Close();
        }

    }
}
