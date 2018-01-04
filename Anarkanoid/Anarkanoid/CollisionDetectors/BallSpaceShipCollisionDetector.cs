using Anarkanoid.Interfaces;

namespace Anarkanoid.CollisionDetectors
{
    public class BallSpaceShipCollisionDetector
    {
        ISpaceShip _spaceShip;

        public BallSpaceShipCollisionDetector(ISpaceShip spaceShip)
        {
            _spaceShip = spaceShip;
        }

        public bool Collides(IBall ball)
        {
            return ball.Position.X >= _spaceShip.Position.X &&
                   ball.Position.X <= _spaceShip.Position.X + (_spaceShip.Size.Width * _spaceShip.Scale.X);
        }
    }
}