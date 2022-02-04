using System;
using System.Drawing;

namespace StandardGraphics
{
    public static class Render
    {
        public static Bitmap GetBitmap(Random rnd, int width, int height, int circles = 100)
        {
            using Bitmap bmp = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(bmp))
            using (Pen pen = new Pen(Color.White))
            {
                gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                gfx.Clear(Color.Black);
                for (int i = 0; i < circles; i++)
                {
                    pen.Color = Color.FromArgb(rnd.Next());

                    float x = rnd.Next(bmp.Width);
                    float y = rnd.Next(bmp.Height);
                    float size = rnd.Next(10);

                    gfx.DrawEllipse(pen, x, y, size, size);
                }
            }
            return bmp;
        }
    }
}
