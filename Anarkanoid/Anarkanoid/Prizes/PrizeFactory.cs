using Anarkanoid.Core;
using Anarkanoid.Interfaces;
using Anarkanoid.Shooters;
using Microsoft.Xna.Framework;

namespace Anarkanoid.Prizes
{
    public class PrizeFactory
    {
        IComponentManager _componentManager;
        ShooterFactory _shooterFactory;
        ResourceRepository _resourceRepository;

        public PrizeFactory(IComponentManager componentManager, ResourceRepository resourceRepository, ShooterFactory shooterFactory)
        {
            _componentManager = componentManager;
            _resourceRepository = resourceRepository;
            _shooterFactory = shooterFactory;
        }

        public IPrize GetFireBallPrize(Vector2 initialPosition)
        {
            var texture = _resourceRepository.GetTextureByType(typeof(FireBallPrize));
            return new FireBallPrize(initialPosition, new Size(texture.Width, texture.Height), _componentManager);
        }

        public IPrize GetThreeBallsPrize(Vector2 initialPosition)
        {
            var texture = _resourceRepository.GetTextureByType(typeof(ThreeBallsPrize));
            return new ThreeBallsPrize(initialPosition, new Size(texture.Width, texture.Height), _componentManager);
        }

        public IPrize GetWiderSpaceShipPrize(Vector2 initialPosition)
        {
            var texture = _resourceRepository.GetTextureByType(typeof(WiderSpaceShipPrize));
            return new WiderSpaceShipPrize(initialPosition, new Size(texture.Width, texture.Height), _componentManager.SpaceShip);
        }

        public IPrize GetBasicShooterPrize(Vector2 initialPosition)
        {
            var texture = _resourceRepository.GetTextureByType(typeof(BasicShooterPrize));
            return new BasicShooterPrize(initialPosition, new Size(texture.Width, texture.Height), _componentManager.SpaceShip, _shooterFactory);
        }

        public IPrize GetSlowDownBallPrize(Vector2 initialPosition)
        {
            var texture = _resourceRepository.GetTextureByType(typeof(SlowDownBallPrize));
            return new SlowDownBallPrize(initialPosition, new Size(texture.Width, texture.Height), _componentManager.Balls);
        }
    }
}