using System.Timers;
using Anarkanoid.Commands;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.MatchStates
{
    public class InitialMatchState : MatchState
    {
        Timer _timer;

        public InitialMatchState(IAnarkanoidGame arkanoidGame, IKeysConfiguration keysConfiguration) : base(arkanoidGame, keysConfiguration)
        {
            //Components.SpaceShip.Reset();
            //Components.Ball.Reset();

            //BORRAR PREMIOS
            AnarkanoidGame.ComponentManager.RemovePrizes();

            _timer = new Timer(Configuration.BallInitialHookedMiliseconds);
            _timer.Elapsed += (sender, e) =>
            {
                foreach(IBall currentBall in Components.Balls)
                {
                    currentBall.Unhook();
                }
                _timer.Stop();
                _timer.Dispose();
            };
            _timer.Start();

            CommandPerKey.Add(Keys.Left, CommandsFactory.GetMoveSpaceShipToLeftCommand());
            CommandPerKey.Add(Keys.Right, CommandsFactory.GetMoveSpaceShipToRightCommand());
            CommandPerKey.Add(Keys.Shoot, CommandsFactory.GetUnhookBallCommand());
        }

        protected override MatchState Update()
        {
            if (Components.Balls[0].Hooked)
            {
                new SetHookedBallPositionCommand(AnarkanoidGame).Execute();
                //Components.Ball.Position = new Vector2(Components.SpaceShip.Position.X + 10, Components.SpaceShip.Position.Y - Components.Ball.Size.Height * Configuration.BallScale - .1f);
                Components.SpaceShip.Move();
                foreach(IBall currentBall in Components.Balls)
                {
                    currentBall.Move();
                }
                return this;
            }
            else
            {
                return new PlayingState(AnarkanoidGame, Keys);
            }
        }
    }
}