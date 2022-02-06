using System;
using System.Collections.Generic;
using System.Drawing;


namespace Model
{
    public class Star
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Size { get; set; }
        public Color Color { get; set; }

        public const int MaxSize = 30;
        public static Dictionary<StarColor, Color> Colors = new Dictionary<StarColor, Color>()
        {
            { StarColor.White, Color.FromArgb(255, 255, 255) },
            { StarColor.Blue, Color.FromArgb(150, 255, 255) },
            { StarColor.Red, Color.FromArgb(255, 214, 208) },
            { StarColor.Yellow, Color.FromArgb(255, 255, 200) },
        };
    }

    public enum StarColor
    {
        White,
        Blue,
        Red,
        Yellow
    }
}
