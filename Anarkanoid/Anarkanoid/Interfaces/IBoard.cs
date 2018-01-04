using System.Collections.Generic;

namespace Anarkanoid.Interfaces
{
    public interface IBoard : IBlockObserver
    {
        IEnumerable<IBlock> Blocks { get; }

        IEnumerable<IBlock> IrromptableBlocks { get; }

        IBlock Collides(IBall ball);

        //void AddBlock(IBlock block);

        //void RemoveBlock(IBlock block);
    }
}