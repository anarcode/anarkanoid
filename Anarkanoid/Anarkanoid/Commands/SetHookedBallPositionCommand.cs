using Microsoft.Xna.Framework;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Commands
{
    public class SetHookedBallPositionCommand : Command
    {
        public SetHookedBallPositionCommand(IAnarkanoidGame arkanoidGame) : base(arkanoidGame)
        {
        }

        protected override void ExecuteCommand()
        {
            var spaceShip = ArkanoidGame.ComponentManager.SpaceShip;
            var ballScale = ArkanoidGame.ComponentManager.Configuration.BallScale;
            foreach (IBall currentBall in ArkanoidGame.ComponentManager.Balls)
            {
                currentBall.Position = new Vector2(spaceShip.Position.X + 10, spaceShip.Position.Y - currentBall.Size.Height * ballScale.X - .1f);
            }
        }
    }
}