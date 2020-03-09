using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace screenProtector
{
    /// <summary>
    /// Lógica de interacción para VideoBox.xaml
    /// </summary>
    public partial class VideoBox : Window
    {
        public VideoBox(string path)
        {
            InitializeComponent();
            Uri videoUri = new Uri(path);
            Video.Source = videoUri;
        }

        private void Video_MediaEnded(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
