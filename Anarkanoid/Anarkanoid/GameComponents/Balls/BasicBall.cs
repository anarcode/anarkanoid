using Microsoft.Xna.Framework;
using System;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.GameComponents.Balls
{
    public class BasicBall : MobileGameComponent, IBall
    {
        const float MINIMUM_LEFT = 0;
        readonly float MAXIMUM_RIGHT;
        readonly float MAXIMUM_BOTTOM;
        const float MAXIMUN_TOP = 0;

        Vector2 _speedBeforeCollision;

        public virtual bool Rebounds
        {
            get { return true; }
        }

        public bool IsGoingUp
        {
            get { return Speed.Y < 0; }
        }

        public bool IsGoingLeft
        {
            get { return Speed.X < 0; }
        }

        public bool Hooked { get; set; }

        public BasicBall(IGameConfiguration configuration, Size size) : base(configuration, size)
        {
            Scale = Configuration.BallScale;
            MAXIMUM_RIGHT = Configuration.ScreenSize.Width - (Size.Width * Scale.X);
            MAXIMUM_BOTTOM = (float)Math.Round(Configuration.BallMaximumBottomPosition - (Size.Height * Scale.Y), 0) - 1;

            Reset();
        }

        public void Unhook()
        {
            Hooked = false;
            Speed = Configuration.BallInitialSpeed;
        }

        public override void Move()
        {
            float horizontalSpeed = Speed.X;
            if (Position.X == MAXIMUM_RIGHT || Position.X == MINIMUM_LEFT)
            {
                horizontalSpeed = _speedBeforeCollision.X * -1;
            }
            else
            {
                _speedBeforeCollision.X = horizontalSpeed;
                bool isGoingToRight = Speed.X > 0;
                if (isGoingToRight)
                {
                    horizontalSpeed = Math.Min(horizontalSpeed, MAXIMUM_RIGHT - Position.X);
                }
                else
                {
                    horizontalSpeed = Math.Min(Math.Abs(horizontalSpeed), Position.X) * -1;
                }
            }

            float verticalSpeed = Speed.Y;
            if (Position.Y == MAXIMUN_TOP)
            {
                verticalSpeed = _speedBeforeCollision.Y * -1;
            }
            else
            {
                _speedBeforeCollision.Y = verticalSpeed;
                bool isGoingToUp = Speed.Y < 0;
                if (isGoingToUp)
                {
                    verticalSpeed = Math.Min(Math.Abs(verticalSpeed), Position.Y) * -1;
                }
                else
                {
                    verticalSpeed = Math.Min(verticalSpeed, Math.Abs(MAXIMUM_BOTTOM - Position.Y + (Size.Height * Scale.Y)));
                    if(verticalSpeed == 0)
                    {
                        base.Move();
                        return;
                    }
                }
            }

            Speed = new Vector2(horizontalSpeed, verticalSpeed);
            base.Move();
        }

        public override void Reset()
        {
            float coordinateX = Configuration.ScreenSize.Width / 2 - Size.Width / 2;
            float coordinateY = MAXIMUM_BOTTOM + 1;
            Position = new Vector2(coordinateX, coordinateY);
            _speedBeforeCollision = Configuration.BallInitialSpeed;
            Hooked = true;
        }

        public virtual IBall Clone()
        {
            return new BasicBall(Configuration, Size)
            {
                Hooked = Hooked,
                Position = Position,
                Scale = Scale,
                Speed = Speed,
                SpriteColor = SpriteColor
            };
        }
    }
}