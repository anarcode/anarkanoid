using System.Timers;
using Anarkanoid.Commands;
using Anarkanoid.Core;
using Anarkanoid.GameComponents;
using Anarkanoid.Interfaces;
using System;

namespace Anarkanoid.MatchStates
{
    public class NewMatchState : MatchState
    {
        const string LEVEL_TEXT = "Level {0}";
        const string TEXT_FORMAT = "Player 1 READY in {0}...";
        const int TOTAL_TICKS = 3;
        int _totalTicks = 0;
        IGameComponent _levelText, _text;
        Timer _timer;
        MatchState _returnState;

        public NewMatchState(IAnarkanoidGame arkanoidGame, IKeysConfiguration keysConfiguration) : base(arkanoidGame, keysConfiguration)
        {
            AnarkanoidGame.ComponentManager.Clear();
            AnarkanoidGame.CurrentLives = Configuration.InitialLives;

            _levelText = new ShowText(Configuration, new Size(Configuration.ScreenSize.Width, Configuration.ScreenSize.Height))
            {
                Position = new Microsoft.Xna.Framework.Vector2(150, 120)
            };
            AnarkanoidGame.ComponentManager.AddText(_levelText, string.Format(LEVEL_TEXT, AnarkanoidGame.CurrentStage + 1));

            _text = new ShowText(Configuration, new Size(Configuration.ScreenSize.Width, Configuration.ScreenSize.Height))
            {
                Position = new Microsoft.Xna.Framework.Vector2(150, 150)
            };
            AnarkanoidGame.ComponentManager.AddText(_text, string.Format(TEXT_FORMAT, 3 - _totalTicks));

            Components.SpaceShip.Reset();
            AnarkanoidGame.ComponentManager.AddSpaceShip(AnarkanoidGame.ComponentManager.SpaceShip);

            var ball = AnarkanoidGame.ComponentManager.BallRepository.GetBasicBall();
            ball.Reset();
            AnarkanoidGame.ComponentManager.AddBall(ball);

            var boardFileName = Environment.CurrentDirectory + "\\Boards\\" + AnarkanoidGame.ComponentManager.Configuration.Boards[AnarkanoidGame.CurrentStage] + ".stage";
            var boardDefinition = new BoardDefinition(boardFileName);
            AnarkanoidGame.ComponentManager.LoadBoard(boardDefinition);

            _timer = new Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
            _returnState = this;

            CommandPerKey.Add(Keys.Left, CommandsFactory.GetMoveSpaceShipToLeftCommand());
            CommandPerKey.Add(Keys.Right, CommandsFactory.GetMoveSpaceShipToRightCommand());
        }
            
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(_totalTicks == TOTAL_TICKS - 1)
            {
                _totalTicks++;
                AnarkanoidGame.ComponentManager.AddText(_text, "... PAMPLINAS ...");
            }
            else if(_totalTicks == TOTAL_TICKS)
            {
                AnarkanoidGame.ComponentManager.Remove(_text);
                AnarkanoidGame.ComponentManager.Remove(_levelText);
                _returnState = new InitialMatchState(AnarkanoidGame, Keys);
                _timer.Stop();
                _timer.Dispose();
            }
            else
            {
                _totalTicks++;
                AnarkanoidGame.ComponentManager.AddText(_text, string.Format(TEXT_FORMAT, 3 - _totalTicks));
            }
        }

        protected override MatchState Update()
        {
            new SetHookedBallPositionCommand(AnarkanoidGame).Execute();
            Components.SpaceShip.Move();
            foreach (IBall currentBall in Components.Balls)
            {
                currentBall.Move();
            }
            return _returnState;
        }
    }
}