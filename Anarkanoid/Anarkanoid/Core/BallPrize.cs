using Anarkanoid.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Anarkanoid.Core
{
    public abstract class BallPrize : Prize
    {
        protected IEnumerable<IBall> Balls { get; private set; }

        protected BallPrize(Vector2 initialPosition, Size size, IEnumerable<IBall> balls) : base(initialPosition, size)
        {
            Balls = balls;
        }
    }
}