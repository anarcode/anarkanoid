using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.GameComponents.Blocks
{
    public class IrromptableBlock : Block
    {
        public override bool Breakable
        {
            get { return false; }
        }

        public IrromptableBlock(IGameConfiguration configuration, Size size) : base(configuration, size)
        {
        }

        public override void Explode()
        {
        }
    }
}