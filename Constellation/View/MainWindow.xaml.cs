using Model;
using Renderer;
using System;
using System.Windows;
using System.Windows.Threading;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cosmos cosmos;
        DispatcherTimer timer = new DispatcherTimer();

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
            Result.InvalidateVisual();
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
            var renderer = new RendererSkiaSharp(e.Surface.Canvas);
            cosmos.Render(renderer);
        }
    }
}
