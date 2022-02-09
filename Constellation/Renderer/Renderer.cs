using Model;
using SkiaSharp;

namespace Renderer
{
    public class RendererSkiaSharp : IRenderer
    {
        private SKCanvas _canvas;
        private SKPaint _paint;

        public RendererSkiaSharp(int width, int height)
        {
            var imageInfo = new SKImageInfo(
                width: width,
                height: height,
                colorType: SKColorType.Rgba8888,
                alphaType: SKAlphaType.Premul);
            var surface = SKSurface.Create(imageInfo);

            _canvas = surface.Canvas;
            _paint = new SKPaint()
            {
                IsAntialias = true,
            };
        }

        private SKColor ConvertColor(Color color)
        {
            return new SKColor(color.R, color.G, color.B, color.A);
        }

        private SKPoint ConvertPoint(Point pt)
        {
            return new SKPoint((float)pt.X, (float)pt.Y);
        }

        public void Clear(Color color)
        {
            _canvas.Clear(ConvertColor(color));
        }

        public void Dispose()
        {
            _paint.Dispose();
        }

        public void DrawLine(Point pt1, Point pt2, double lineWidth, Color color)
        {
            _paint.Color = ConvertColor(color);
            _canvas.DrawLine(ConvertPoint(pt1), ConvertPoint(pt2), _paint);
        }

        public void FillCircle(Point center, double radius, Color color)
        {
            _paint.Color = ConvertColor(color);
            _canvas.DrawCircle(ConvertPoint(center), (float)radius, _paint);
        }
    }
}
