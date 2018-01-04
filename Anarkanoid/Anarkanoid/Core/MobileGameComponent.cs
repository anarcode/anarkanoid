using Microsoft.Xna.Framework;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Core
{
    public abstract class MobileGameComponent : GameComponent, IMobileGameComponent
    {
        public Vector2 Speed { get; set; }

        protected MobileGameComponent(IGameConfiguration configuration, Size size) : base(configuration, size)
        {
            Speed = new Vector2();
        }

        public virtual void Move() //Esto a Ball, no?
        {
            float coordinateX = Position.X + Speed.X;
            float coordinateY = Position.Y + Speed.Y;
            Position = new Vector2(coordinateX, coordinateY);
        }

        public abstract void Reset();
    }
}