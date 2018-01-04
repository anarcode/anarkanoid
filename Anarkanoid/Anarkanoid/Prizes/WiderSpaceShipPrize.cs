using Anarkanoid.Core;
using Anarkanoid.Interfaces;
using Microsoft.Xna.Framework;

namespace Anarkanoid.Prizes
{
    public class WiderSpaceShipPrize : SpaceShipPrize
    {
        public WiderSpaceShipPrize(Vector2 initialPosition, Size size, ISpaceShip spaceShip) : base(initialPosition, size, spaceShip)
        {
        }

        public override void Apply()
        {
            SpaceShip.Scale = new Vector2(SpaceShip.Scale.X + .1f, SpaceShip.Scale.Y);
        }
    }
}