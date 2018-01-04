using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.GameComponents.Balls
{
    public class FireBall : BasicBall
    {
        public override bool Rebounds
        {
            get { return false; }
        }

        public FireBall(IGameConfiguration configuration, Size size) : base(configuration, size)
        {
        }

        public override IBall Clone()
        {
            return new FireBall(Configuration, Size)
            {
                Hooked = Hooked,
                Position = Position,
                Scale = Scale,
                Speed = Speed,
                SpriteColor = SpriteColor
            };
        }
    }
}