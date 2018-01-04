using Anarkanoid.Core;
using Microsoft.Xna.Framework;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Prizes
{
    public class ThreeBallsPrize : Prize
    {
        IComponentManager _componentManager;

        public ThreeBallsPrize(Vector2 initialPosition, Size size, IComponentManager componentManager) : base(initialPosition, size)
        {
            _componentManager = componentManager;
        }

        public override void Apply()
        {
            var ball = _componentManager.Balls[0].Clone();
            ball.Speed = new Vector2(ball.Speed.X * -1, ball.Speed.Y);
            _componentManager.AddBall(ball);

            ball = _componentManager.Balls[0].Clone();
            ball.Speed = new Vector2(ball.Speed.X, ball.Speed.Y * -1);
            _componentManager.AddBall(ball);
        }
    }
}