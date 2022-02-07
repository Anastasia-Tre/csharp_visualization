using System.Drawing;

namespace Model
{
    public static class Render
    {
        public static void GenerateStars(Bitmap bmp, Star[] stars)
        {
            using Graphics gfx = Graphics.FromImage(bmp);
            using SolidBrush brush = new SolidBrush(Color.White);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gfx.Clear(Color.Black);
            for (int i = 0; i < stars.GetLength(0); i++)
            {
                brush.Color = stars[i].Color;

                float x = stars[i].X * bmp.Width;
                float y = stars[i].Y * bmp.Height;
                float size = stars[i].Size;

                gfx.FillEllipse(brush, x - size, y - size, size * 2, size * 2);
            }

        }
    }
}
