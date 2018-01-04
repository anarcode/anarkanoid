using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Shooters
{
    public class ShooterFactory
    {
        IGameConfiguration _configuration;
        ResourceRepository _resourceRepository;
        ISpaceShip _spaceShip;

        public ShooterFactory(IGameConfiguration configuration, ResourceRepository resourceRepository, ISpaceShip spaceShip)
        {
            _configuration = configuration;
            _resourceRepository = resourceRepository;
            _spaceShip = spaceShip;
        }

        public IShooter GetBasicShooter()
        {
            var texture =_resourceRepository.GetTextureByAssetName("BasicShoot");
            return new BasicShooter(_configuration, new Size(texture.Width, texture.Height), _spaceShip);
        }
    }
}