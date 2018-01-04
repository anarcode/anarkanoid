using System;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;
using Microsoft.Xna.Framework;

namespace Anarkanoid.GameComponents.Shoots
{
    public class BasicShoot : MobileGameComponent, IShoot
    {
        Vector2 _initialPosition;

        public BasicShoot(IGameConfiguration configuration, Size size, Vector2 initialPosition) : base(configuration, size)
        {
            _initialPosition = Position = initialPosition;
            Speed = new Vector2(0, -5);
        }

        public override void Move()
        {
            base.Move();
        }

        public override void Reset()
        {
            Position = _initialPosition;
        }
    }
}