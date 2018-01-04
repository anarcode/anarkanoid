using Anarkanoid.Core;
using Microsoft.Xna.Framework;
using Anarkanoid.Interfaces;
using System.Collections.Generic;
using System.Timers;

namespace Anarkanoid.Prizes
{
    public class FireBallPrize : Prize
    {
        IComponentManager _componentManager;

        public FireBallPrize(Vector2 initialPosition, Size size, IComponentManager componentManager) : base(initialPosition, size)
        {
            _componentManager = componentManager;
        }

        public override void Apply()
        {
            List<IBall> fireBalls = new List<IBall>();
            foreach (IBall currentBall in _componentManager.Balls)
            {
                var fireBall = _componentManager.BallRepository.GetFireBall();
                fireBall.Position = currentBall.Position;
                fireBall.Speed = currentBall.Speed;
                fireBalls.Add(fireBall);
            }
            _componentManager.RemoveBalls();

            foreach (IBall currentFireBall in fireBalls)
            {
                _componentManager.AddBall(currentFireBall);
            }

            Timer timer = new Timer(3000);
            timer.Elapsed += ((o, e) =>
            {
                List<IBall> basicBalls = new List<IBall>();
                foreach (IBall currentBall in _componentManager.Balls)
                {
                    var basicBall = _componentManager.BallRepository.GetBasicBall();
                    basicBall.Position = currentBall.Position;
                    basicBall.Speed = currentBall.Speed;
                    basicBalls.Add(basicBall);
                }
                _componentManager.RemoveBalls();

                foreach (IBall currentFireBall in basicBalls)
                {
                    _componentManager.AddBall(currentFireBall);
                }
                timer.Stop();
            });
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}