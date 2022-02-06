using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Cosmos
    {
        Star[] _stars;
        int Width;
        int Height;
        Random _rnd = new Random();


        Star GetRandomStar()
        {
            return new Star
            {
                X = _rnd.Next(Width),
                Y = _rnd.Next(Height),
                Size = _rnd.Next(Star.MaxSize),
                Color = Star.Colors[(StarColor)_rnd.Next(Star.Colors.Count)]
            };
        }

        public Star[] GetStars() => _stars;
    }
}
