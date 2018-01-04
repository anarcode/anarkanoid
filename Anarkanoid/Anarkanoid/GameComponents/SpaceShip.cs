using Microsoft.Xna.Framework;
using System;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.GameComponents
{
    public class SpaceShip : MobileGameComponent, ISpaceShip
    {
        float _speedBeforeCollision;

        public IShooter Shooter { get; set; }

        public SpaceShip(IGameConfiguration configuration, Size size) : base(configuration, size)
        {
            Reset();
        }

        public override void Move()
        {
            if(Speed.X == 0)
            {
                return;
            }

            bool isGoingToRight = Speed.X > 0;
            var decrement = Math.Min(Configuration.SpaceShipBrakeStep, Math.Abs(Speed.X));
            if (!isGoingToRight)
            {
                decrement *= -1;
            }
            float horizontalSpeed = Speed.X - decrement;
            
            //Ahora compruebo si lo que me tengo que mover es mayor que lo que me queda hasta el "final" del camino
            //Si no puedo hacer todo el movimiento, posiciono para que la proxima iteración detecte la colisión con la pared
            //y cambie el sentido
            float maximumRigth = Configuration.ScreenSize.Width - (Size.Width * Scale.X);
            float minimumLeft = 0;
            if(Position.X == maximumRigth || Position.X == minimumLeft)
            {
                horizontalSpeed = _speedBeforeCollision * -1;
            }
            else
            {
                _speedBeforeCollision = horizontalSpeed;
                if (isGoingToRight)
                {
                    horizontalSpeed = Math.Min(horizontalSpeed, maximumRigth - Position.X);
                    horizontalSpeed = Math.Min(horizontalSpeed, Configuration.SpaceShipMaximumSpeed);
                }
                else
                {
                    horizontalSpeed = Math.Min(Math.Abs(horizontalSpeed), Position.X) * -1;
                    horizontalSpeed = Math.Max(horizontalSpeed, Configuration.SpaceShipMaximumSpeed * -1);
                }
            }

            Speed = new Vector2(horizontalSpeed, 0);
            base.Move();
        }

        public override void Reset()
        {
            float coordinateX = Configuration.ScreenSize.Width / 2 - Size.Width / 2;
            float coordinateY = Configuration.BallMaximumBottomPosition;
            Position = new Vector2(coordinateX, coordinateY);
        }
    }
}