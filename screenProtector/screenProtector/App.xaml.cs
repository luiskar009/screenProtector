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
            List<string> files = Directory.EnumerateFiles(ConfigurationManager.AppSettings["path"], "*.*", SearchOption.AllDirectories)
                .ToList();
                //.Where(s => s.EndsWith(".png") || s.EndsWith(".jpg")).ToList();

            foreach(string file in files)
            {
                if (ConfigurationManager.AppSettings["type"].ToString() == "image")
                    getImagesUpFront(file);
                if (ConfigurationManager.AppSettings["type"].ToString() == "video")
                    getVideosUpFront(file);
                getOutlookUpFront();
                Thread.Sleep(Int32.Parse(ConfigurationManager.AppSettings["time"].ToString()));
            }        

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
                //ShowWindow(s, 2);
                SetForegroundWindow(s);
            }
        }

        public static void getImagesUpFront(string path)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            PictureBox pb = new PictureBox(path);
            pb.ShowDialog();
        }

        public static void getVideosUpFront(string path)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            VideoBox pb = new VideoBox(path);
            pb.ShowDialog();
        }

    }
}
