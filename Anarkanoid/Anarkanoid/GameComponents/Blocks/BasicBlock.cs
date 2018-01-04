using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.GameComponents.Blocks
{
    public class BasicBlock : Block
    {
        public BasicBlock(IGameConfiguration configuration, Size size) : base(configuration, size)
        {
        }
    }
}