using System;
using System.Drawing;

namespace StandardGraphics
{
    public static class Render
    {
        public static void GenerateImage(Bitmap bmp, Random rnd, int circles = 2000)
        {
            using Graphics gfx = Graphics.FromImage(bmp);
            using Pen pen = new Pen(Color.White);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gfx.Clear(Color.White);
            for (int i = 0; i < circles; i++)
            {
                pen.Color = Color.FromArgb(rnd.Next());

                float x = rnd.Next(bmp.Width);
                float y = rnd.Next(bmp.Height);
                float size = rnd.Next(30);

                gfx.DrawEllipse(pen, x, y, size, size);
            }

        }
    }
}
