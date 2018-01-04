using Anarkanoid.Interfaces;
using Microsoft.Xna.Framework;

namespace Anarkanoid.Core
{
    public abstract class Prize : IPrize
    {
        Vector2 _initialPosition;

        public Vector2 Position { get; set; }

        public Vector2 Scale { get; set; }

        public Size Size { get; set; }

        public Vector2 Speed { get; set; }

        public Color SpriteColor { get; set; }

        protected Prize(Vector2 initialPosition, Size size)
        {
            _initialPosition = Position = initialPosition;
            Size = size;
            Scale = new Vector2(1, 1);
            SpriteColor = Color.White;
            Speed = new Vector2(0, 1);
        }

        public abstract void Apply();

        public void Move()
        {
            Position = new Vector2(Position.X + Speed.X, Position.Y + Speed.Y);
        }

        public void Reset()
        {
            Position = _initialPosition;
        }
    }
}