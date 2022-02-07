using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ViewWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cosmos cosmos = new Cosmos();
        Stopwatch stopwatch = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timerTick;
        }

        private void timerTick(object sender, EventArgs e)
        {
            stopwatch.Restart();
            cosmos.MoveStars();

            Bitmap bmp = new Bitmap((int)ResultCanvas.ActualWidth, (int)ResultCanvas.ActualHeight);
            Render.GenerateStars(bmp, cosmos.GetStars());
            ResultImage.Source = BitmapToBitmapImage(bmp);

            double elapsedSec = (double)stopwatch.ElapsedTicks / Stopwatch.Frequency;
            Title = $"Cosmos - {elapsedSec * 1000:0.00} ms ({1 / elapsedSec:0.00} FPS)";
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

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
