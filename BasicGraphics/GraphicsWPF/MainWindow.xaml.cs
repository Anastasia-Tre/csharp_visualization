using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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
            Render(ResultCanvas);
        }

        private void Render(Canvas canvas)
        {
            Ellipse ellipse = new Ellipse
            {
                Height = 150,
                Width = 150,
            };
            ellipse.Fill = Brushes.Red;
            canvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, 30);
            Canvas.SetTop(ellipse, 30);
        }
    }
}
