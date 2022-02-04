using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GraphicsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            Render();
        }

        private void Render()
        {
            Random rnd = new Random();
            using Bitmap bmp = new Bitmap((int)ResultCanvas.ActualWidth, (int)ResultCanvas.ActualHeight);
            StandardGraphics.Render.GenerateImage(bmp, rnd, 500);
            ResultImage.Source = BitmapToBitmapImage(bmp);
        }

        private BitmapImage BitmapToBitmapImage(Bitmap bmp)
        {
            using var memory = new System.IO.MemoryStream();
            bmp.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
            memory.Position = 0;

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memory;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            bitmapImage.Freeze();

            return bitmapImage;
        }

    }
}
