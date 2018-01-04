using Anarkanoid.Core;
using Anarkanoid.Interfaces;
using Anarkanoid.Shooters;
using Microsoft.Xna.Framework;

namespace Anarkanoid.Prizes
{
    public class BasicShooterPrize : SpaceShipPrize
    {
        ShooterFactory _shooterFactory;

        public BasicShooterPrize(Vector2 initialPosition, Size size, ISpaceShip spaceShip, ShooterFactory shooterFactory) : base(initialPosition, size, spaceShip)
        {
            _shooterFactory = shooterFactory;
        }

        public override void Apply()
        {
            SpaceShip.Shooter = _shooterFactory.GetBasicShooter();
        }
    }
}