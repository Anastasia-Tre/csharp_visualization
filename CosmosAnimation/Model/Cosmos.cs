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
                X = (float)_rnd.NextDouble(),
                Y = (float)_rnd.NextDouble(),
                Size = _rnd.Next(Star.MaxSize),
                Color = Star.Colors[(StarColor)_rnd.Next(Star.Colors.Count)]
            };
        }

        public Star[] GetStars() => _stars;

        public void MoveStars(float step = .01f)
        {
            for (int i = 0; i < StarsCount; i++)
            {
                _stars[i].X += (_stars[i].X - .5f) * _stars[i].Size * step;
                _stars[i].Y += (_stars[i].Y - .5f) * _stars[i].Size * step;
                _stars[i].Size += _stars[i].Size * step * 2;

                // check if star out of borders
                if (_stars[i].X < 0 || _stars[i].X > Width ||
                    _stars[i].Y < 0 || _stars[i].Y > Height)
                    _stars[i] = GetRandomStar();
            }
        }
    }
}
