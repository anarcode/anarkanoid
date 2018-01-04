using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Commands
{
    public class UnhookBallCommand : Command
    {
        public UnhookBallCommand(IAnarkanoidGame arkanoidGame) : base(arkanoidGame)
        {
        }

        protected override void ExecuteCommand()
        {
            foreach(IBall currentBall in ArkanoidGame.ComponentManager.Balls)
            {
                currentBall.Unhook();
            }
        }
    }
}