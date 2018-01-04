using Microsoft.Xna.Framework;
using Anarkanoid.Core;
using Anarkanoid.GameComponents;
using Anarkanoid.Interfaces;
using Anarkanoid.CollisionDetectors;
using System.Collections.Generic;
using System.Timers;

namespace Anarkanoid.MatchStates
{
    public class PlayingState : MatchState
    {
        const string CURRENT_LIVES_TEXT_FORMAT = "Lives: {0}";

        ShowText _currentLivesText;
        BallSpaceShipCollisionDetector _collisionDetector;
        SpaceShipPrizeCollisionDetector _prizeCollisionDetector;
        ShootBlockCollisionDetector _shootBlockCollisionDetector;
        bool _waitingForNexShoot;

        public PlayingState(IAnarkanoidGame arkanoidGame, IKeysConfiguration keysConfiguration) : base(arkanoidGame, keysConfiguration)
        {
            _currentLivesText = new ShowText(Configuration, new Size(Configuration.ScreenSize.Width, Configuration.ScreenSize.Height));
            AnarkanoidGame.ComponentManager.AddText(_currentLivesText, string.Format(CURRENT_LIVES_TEXT_FORMAT, AnarkanoidGame.CurrentLives));
            //AnarkanoidGame.ComponentManager.SpaceShip.Shooter = new Shooters.BasicShooter(AnarkanoidGame.ComponentManager.Configuration, new Size(30, 20), AnarkanoidGame.ComponentManager.SpaceShip);

            CommandPerKey.Add(Keys.Left, CommandsFactory.GetMoveSpaceShipToLeftCommand());
            CommandPerKey.Add(Keys.Right, CommandsFactory.GetMoveSpaceShipToRightCommand());
            CommandPerKey.Add(Keys.Shoot, CommandsFactory.GetActionCommand(Shoot));

            _collisionDetector = new BallSpaceShipCollisionDetector(Components.SpaceShip);
            _prizeCollisionDetector = new SpaceShipPrizeCollisionDetector(AnarkanoidGame.ComponentManager.SpaceShip);
            _shootBlockCollisionDetector = new ShootBlockCollisionDetector();
        }

        protected override MatchState Update()
        {
            var remainingBlocks = new List<IBlock>(AnarkanoidGame.ComponentManager.Board.Blocks).Count;
            if(remainingBlocks == 0)
            {
                AnarkanoidGame.CurrentStage++;
                if(AnarkanoidGame.CurrentStage == AnarkanoidGame.ComponentManager.Configuration.Boards.Count)
                {
                    //WinPage
                }
                else
                {
                    return new NextStageState(AnarkanoidGame, Keys);
                }
            }

            AnarkanoidGame.ComponentManager.AddText(_currentLivesText, string.Format(CURRENT_LIVES_TEXT_FORMAT, AnarkanoidGame.CurrentLives));
            Components.SpaceShip.Move();

            var spaceShip = Components.SpaceShip;
            var ballEnumerator = new List<IBall>(Components.Balls).GetEnumerator();
            while (ballEnumerator.MoveNext())
            {
                var currentBall = ballEnumerator.Current;
                currentBall.Move();
                if (currentBall.Position.Y >= Configuration.BallMaximumBottomPosition - (currentBall.Size.Height * currentBall.Scale.Y) &&
                !currentBall.IsGoingUp)
                {
                    if (_collisionDetector.Collides(currentBall))
                    {
                        currentBall.Speed = new Vector2(spaceShip.Speed.X + currentBall.Speed.X, currentBall.Speed.Y * -1);
                    }
                    else
                    {
                        //Comporbar cuantas bolas hay
                        if (Components.Balls.Count > 1)
                        {
                            //Quito la bola que se ha pirado
                            AnarkanoidGame.ComponentManager.RemoveBall(currentBall); //Esto va a reventar por el enumerator
                        }
                        else
                        {
                            AnarkanoidGame.ComponentManager.Remove(_currentLivesText);
                            return new DeadState(AnarkanoidGame, Keys);
                        }
                    }
                }

                var collisionBlock = AnarkanoidGame.ComponentManager.Board.Collides(currentBall);
                if (collisionBlock != null)
                {
                    collisionBlock.Explode();
                }
            }

            var prizesEnumerator = new List<IPrize>(AnarkanoidGame.ComponentManager.Prizes).GetEnumerator();
            while (prizesEnumerator.MoveNext())
            {
                var prize = prizesEnumerator.Current;
                if (_prizeCollisionDetector.Collides(prize))
                {
                    prize.Apply();
                    AnarkanoidGame.ComponentManager.RemovePrize(prize);
                }
                else if (prize.Position.Y >= AnarkanoidGame.ComponentManager.Configuration.BallMaximumBottomPosition)
                {
                    AnarkanoidGame.ComponentManager.RemovePrize(prize);
                }
                else
                {
                    prize.Move();
                }
            }

            var shootsEnumerator = new List<IShoot>(AnarkanoidGame.ComponentManager.Shoots).GetEnumerator();
            while (shootsEnumerator.MoveNext())
            {
                var shoot = shootsEnumerator.Current;
                bool collisionDetected = false;
                var blocksEnumerator = new List<IBlock>(AnarkanoidGame.ComponentManager.Board.Blocks).GetEnumerator();
                while (blocksEnumerator.MoveNext() && !collisionDetected)
                {
                    var block = blocksEnumerator.Current;
                    if (_shootBlockCollisionDetector.Collides(shoot, block))
                    {
                        collisionDetected = true;
                        block.Explode();
                    }
                }

                if (collisionDetected)
                {
                    AnarkanoidGame.ComponentManager.RemoveShoot(shoot);
                }
                else
                {
                    shoot.Move();
                }
            }

            return this;
        }

        void Shoot()
        {
            if(AnarkanoidGame.ComponentManager.SpaceShip.Shooter != null)
            {
                if (!_waitingForNexShoot)
                {
                    _waitingForNexShoot = true;
                    AnarkanoidGame.ComponentManager.AddShoot(AnarkanoidGame.ComponentManager.SpaceShip.Shooter.Shoot());
                    Timer timer = new Timer(1000);
                    timer.Elapsed += ((o, e) => _waitingForNexShoot = false);
                    timer.Start();
                }
            }
        }
    }
}