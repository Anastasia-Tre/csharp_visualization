using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model 
{
    class Cosmos : IDisposable
    {
        public int StarsCount { get; set; } = 500;
        public float Width { get; set; } = 500;
        public float Height { get; set; } = 500;

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
            throw new NotImplementedException();
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

        
    }
}
