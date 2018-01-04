using Anarkanoid.Core;
using Anarkanoid.Interfaces;
using Anarkanoid.GameComponents.Shoots;

namespace Anarkanoid.Shooters
{
    public class BasicShooter : IShooter
    {
        IGameConfiguration _configuration;
        Size _size;
        ISpaceShip _spaceShip;

        public BasicShooter(IGameConfiguration configuration, Size size, ISpaceShip spaceShip)
        {
            _configuration = configuration;
            _size = size;
            _spaceShip = spaceShip;
        }

        public IShoot Shoot()
        {
            return new BasicShoot(_configuration, _size, _spaceShip.Position);
        }
    }
}