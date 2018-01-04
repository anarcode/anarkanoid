using Anarkanoid.Interfaces;

namespace Anarkanoid.CollisionDetectors
{
    public class ShootBlockCollisionDetector : RectangleCollisionDetector
    {
        public ShootBlockCollisionDetector()
        {
        }

        public bool Collides(IShoot shoot, IBlock block)
        {
            return base.Collides(shoot, block);
        }
    }
}