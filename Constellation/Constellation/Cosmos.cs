using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model 
{
    public class Cosmos : IDisposable
    {
        public int StarsCount { get; set; } = 300;
        public float Width { get; set; } = 960;
        public float Height { get; set; } = 430;

        Star[] _stars;
        Random _rnd = new Random();
        Thread mainThread;
        bool isRunning = true;

        public Cosmos()
        {
            _stars = new Star[StarsCount];
            for (int i = 0; i < StarsCount; i++)
            {
                _stars[i] = GetRandomStar();
            }

            mainThread = new Thread(new ThreadStart(RunMainThread));
            mainThread.Start();
        }

        void RunMainThread()
        {
            while (isRunning)
            {
                MoveStars();
                Thread.Sleep(1);
            }
        }


        public void Dispose()
        {
            isRunning = false;
        }

        Star GetRandomStar(float minVelocity = .1f)
        {
            return new Star
            {
                X = (float)_rnd.NextDouble() * Width,
                Y = (float)_rnd.NextDouble() * Height,
                XVel = minVelocity + (float)_rnd.NextDouble(),
                YVel = minVelocity + (float)_rnd.NextDouble(),
            };
        }

        public Star[] GetStars()
        {
            return _stars;
        }

        public void MoveStars(float step = .04f)
        {
            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i].X += _stars[i].XVel * step;
                _stars[i].Y += _stars[i].YVel * step;

                bool outOfBoundsX = (_stars[i].X < 0) || (_stars[i].X > Width);
                bool outOfBoundsY = (_stars[i].Y < 0) || (_stars[i].Y >= Height);

                if (outOfBoundsX) _stars[i].XVel *= -1;
                if (outOfBoundsY) _stars[i].YVel *= -1;
            }
        }

        public void Render(IRenderer renderer)
        {
            var backColor = new Color(45, 45, 45);
            renderer.Clear(backColor);

            foreach (var star in _stars)
                renderer.FillCircle(star.Point, star.Size, star.Color);

            double connectDistance = 100;
            foreach (var star1 in _stars)
            {
                foreach (var star2 in _stars)
                {
                    if (star1.Y >= star2.Y)
                        continue;

                    double dX = Math.Abs(star1.X - star2.X);
                    double dY = Math.Abs(star1.Y - star2.Y);
                    double distance = Math.Sqrt(dX * dX + dY * dY);

                    if (distance > connectDistance) continue;
                    
                    int alpha = (int)(255 - distance / connectDistance * 255) * 2;
                    alpha = Math.Min(alpha, 255);
                    alpha = Math.Max(alpha, 0);
                    var lineColor = new Color(255, 255, 255, (byte)alpha);
                    renderer.DrawLine(star1.Point, star2.Point, 1, lineColor);
                }
            }
        }

    }
}
