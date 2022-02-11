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
using Model;
using Renderer;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cosmos cosmos; 
        DispatcherTimer timer = new DispatcherTimer();
        RendererSkiaSharp renderer;

        public MainWindow()
        {
            InitializeComponent();

            cosmos = new Cosmos()
            {
                Width = (float)Result.ActualWidth,
                Height = (float)Result.ActualHeight,
            };

            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timerTick;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            //Bitmap bmp = new Bitmap((int)ResultCanvas.ActualWidth, (int)ResultCanvas.ActualHeight);
            Result.InvalidateVisual();
            
            //cosmos.Render(renderer);
            
            //ResultImage.Source = BitmapToBitmapImage(bmp);

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

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            cosmos.Width = (float)Result.ActualWidth;
            cosmos.Height = (float)Result.ActualHeight;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cosmos.Dispose();
        }

        private void SKElement_PaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            renderer = new RendererSkiaSharp(e.Surface.Canvas);
            cosmos.Render(renderer);
            //renderer.Clear(new Model.Color(134, 170, 45));
            //e.Surface.Canvas.Clear(new SkiaSharp.SKColor(45, 45, 45));
        }
    }
}
