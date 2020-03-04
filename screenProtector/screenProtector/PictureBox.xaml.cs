using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para PictureBox.xaml
    /// </summary>
    public partial class PictureBox : Window
    {
        public PictureBox(string path)
        {
            InitializeComponent();
            Uri imageUri = new Uri(path);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            Picture.Source = imageBitmap;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            this.Close();
        }
    }
}

