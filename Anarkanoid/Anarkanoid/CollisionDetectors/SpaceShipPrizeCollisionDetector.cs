using Anarkanoid.Interfaces;

namespace Anarkanoid.CollisionDetectors
{
    public class SpaceShipPrizeCollisionDetector : RectangleCollisionDetector
    {
        ISpaceShip _spaceShip;

        public SpaceShipPrizeCollisionDetector(ISpaceShip spaceShip)
        {
            _spaceShip = spaceShip;
        }

        public bool Collides(IPrize prize)
        {
            return base.Collides(_spaceShip, prize);
        }
    }
}