using System;
using System.Collections.Generic;
using System.Drawing;


namespace Model
{
    class Star
    {
        float X { get; set; }
        float Y { get; set; }
        float Size { get; set; }
        Color Color { get; set; }

        public static Dictionary<StarColor, Color> Colors = new Dictionary<StarColor, Color>()
        {
            { StarColor.White, Color.FromArgb(255, 255, 255) },
            { StarColor.Blue, Color.FromArgb(150, 255, 255) },
            { StarColor.Red, Color.FromArgb(255, 214, 208) },
            { StarColor.Yellow, Color.FromArgb(255, 255, 200) },
        };
    }

    enum StarColor
    {
        White,
        Blue,
        Red,
        Yellow
    }
}
