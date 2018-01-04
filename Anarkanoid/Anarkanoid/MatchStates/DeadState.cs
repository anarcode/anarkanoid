using Microsoft.Xna.Framework;
using System;
using System.Timers;
using Anarkanoid.Core;
using Anarkanoid.GameComponents;
using Anarkanoid.Interfaces;

namespace Anarkanoid.MatchStates
{
    public class DeadState : MatchState
    {
        const string DIE_TEXT = "YOU DIE, BITCH!!!";

        Vector2 _ballSpeed;
        Timer _timer;
        bool _timeElapsed;

        public DeadState(IAnarkanoidGame arkanoidGame, IKeysConfiguration keysConfiguration) : base(arkanoidGame, keysConfiguration)
        {
            _ballSpeed = Components.Balls[0].Speed;

            Components.Balls[0].Speed = new Vector2(Components.Balls[0].Speed.X, Components.Balls[0].Speed.Y);

            var textComponent = new ShowText(Configuration, new Size(Configuration.ScreenSize.Width, Configuration.ScreenSize.Height));
            AnarkanoidGame.ComponentManager.AddText(textComponent, DIE_TEXT);

            _timer = new Timer(Configuration.BallInitialHookedMiliseconds);
            _timer.Elapsed += (sender, e) =>
            {
                AnarkanoidGame.ComponentManager.Remove(textComponent);
                _timeElapsed = true;
                _timer.Stop();
                _timer.Dispose();
            };
            _timer.Start();
            AnarkanoidGame.CurrentLives--;
        }

        protected override MatchState Update()
        {
            if (_timeElapsed)
            {
                if (AnarkanoidGame.CurrentLives == 0)
                {
                    return new GameOverState(AnarkanoidGame, Keys);
                }
                else
                {
                    Components.SpaceShip.Reset();
                    foreach(IBall currentBall in Components.Balls)
                    {
                        currentBall.Reset();
                    }
                    return new InitialMatchState(AnarkanoidGame, Keys);
                }
            }
            else
            {
                Components.Balls[0].Speed = new Vector2(_ballSpeed.X, Math.Abs(_ballSpeed.Y));
                Components.Balls[0].Move();
                return this;
            }
        }
    }
}