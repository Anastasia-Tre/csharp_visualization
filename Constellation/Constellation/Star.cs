using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Star
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float XVel { get; set; }
        public float YVel { get; set; }

        public float Size { get; set; } = 3;
        public Color Color { get; set; } = new Color(255, 255, 255);

    }
}
