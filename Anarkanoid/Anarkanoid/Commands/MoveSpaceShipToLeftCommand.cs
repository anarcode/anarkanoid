using Microsoft.Xna.Framework;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Commands
{
    public class MoveSpaceShipToLeftCommand : Command
    {
        public MoveSpaceShipToLeftCommand(IAnarkanoidGame arkanoidGame) : base(arkanoidGame)
        {
        }

        protected override void ExecuteCommand()
        {
            var spaceShip = ArkanoidGame.ComponentManager.SpaceShip;
            spaceShip.Speed = new Vector2(spaceShip.Speed.X - ArkanoidGame.ComponentManager.Configuration.SpaceShipAccelerationStep, 0);
        }
    }
}