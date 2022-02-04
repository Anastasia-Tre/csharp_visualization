using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsWPF
{
    class DrawFigures
    {
        private Random _rnd = new();
        private Canvas _canvas;
        private SolidColorBrush _brush = new();

        public DrawFigures(Canvas canvas)
        {
            _canvas = canvas;
        }



        private Ellipse GetEllipse()
        {
            Ellipse ellipse = new Ellipse
            {
                Height = _rnd.NextDouble(),
                Width = _rnd.NextDouble(),
                Stroke = GetRandomColorBrush(),
            };
            return ellipse;
        }

        private SolidColorBrush GetRandomColorBrush()
        {
            var randomColor = Color.FromArgb((byte)_rnd.Next(256), (byte)_rnd.Next(256),
                                (byte)_rnd.Next(256), (byte)_rnd.Next(256));
            _brush.Color = randomColor;
            return _brush;
        }
    }
}
