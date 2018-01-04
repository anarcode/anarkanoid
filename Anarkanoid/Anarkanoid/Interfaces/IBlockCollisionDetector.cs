using Anarkanoid.Core;
using Microsoft.Xna.Framework;

namespace Anarkanoid.Interfaces
{
    public interface IBlockCollisionDetector
    {
        BlockCollision Collides(Vector2 position, IBlock block);
    }
}