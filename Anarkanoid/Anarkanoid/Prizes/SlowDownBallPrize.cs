using Anarkanoid.Core;
using Anarkanoid.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Anarkanoid.Prizes
{
    public class SlowDownBallPrize : BallPrize
    {
        public SlowDownBallPrize(Vector2 initialPosition, Size size, IEnumerable<IBall> balls) : base(initialPosition, size, balls)
        {
        }

        public override void Apply()
        {
            foreach(IBall ball in Balls)
            {
                ball.Speed = new Vector2(ball.Speed.X * .8f, ball.Speed.Y * .8f);
            }
        }
    }
}