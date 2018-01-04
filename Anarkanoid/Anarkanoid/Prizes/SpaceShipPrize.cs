using Anarkanoid.Core;
using Anarkanoid.Interfaces;
using Microsoft.Xna.Framework;

namespace Anarkanoid.Prizes
{
    public abstract class SpaceShipPrize : Prize
    {
        protected ISpaceShip SpaceShip { get; private set; }

        protected SpaceShipPrize(Vector2 initialPosition, Size size, ISpaceShip spaceShip) : base(initialPosition, size)
        {
            SpaceShip = spaceShip;
        }
    }
}