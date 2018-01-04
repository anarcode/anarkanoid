using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.GameComponents.Blocks
{
    public class ThreeLivesBlock : Block
    {
        int _lives = 3;

        public ThreeLivesBlock(IGameConfiguration configuration, Size size) : base(configuration, size)
        {
        }

        public override void Explode()
        {
            if (_lives == 0)
            {
                base.Explode();
            }
            else
            {
                _lives--;
            }
        }
    }
}