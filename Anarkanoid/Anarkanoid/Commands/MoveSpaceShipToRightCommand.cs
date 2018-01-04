using Microsoft.Xna.Framework;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Commands
{
    public class MoveSpaceShipToRightCommand : Command
    {
        public MoveSpaceShipToRightCommand(IAnarkanoidGame arkanoidGame) : base(arkanoidGame)
        {
        }

        protected override void ExecuteCommand()
        {
            var spaceShip = ArkanoidGame.ComponentManager.SpaceShip;
            spaceShip.Speed = new Vector2(spaceShip.Speed.X + ArkanoidGame.ComponentManager.Configuration.SpaceShipAccelerationStep, 0);
        }
    }
}