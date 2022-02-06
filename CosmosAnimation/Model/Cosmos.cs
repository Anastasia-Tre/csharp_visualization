using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Cosmos
    {
        public int StarsCount { get; set; } = 200;
        public int Width { get; set; } = 500;
        public int Height { get; set; } = 500;

        Star[] _stars;
        Random _rnd = new Random();

        public Cosmos()
        {
            _stars = new Star[StarsCount];
            for (int i = 0; i < StarsCount; i++)
            {
                _stars[i] = GetRandomStar();
            }
        }

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
