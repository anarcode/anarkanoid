using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Core
{
    public abstract class GameComponent : Interfaces.IGameComponent
    {
        protected IGameConfiguration Configuration { get; private set; }

        public Vector2 Scale { get; set; }

        public Color SpriteColor { get; set; }

        public Size Size { get; set; }

        public virtual Vector2 Position { get; set; }

        protected GameComponent(IGameConfiguration configuration, Size size)
        {
            Scale = new Vector2(1, 1);
            SpriteColor = Color.White;
            Position = new Vector2(0, 0);
            Configuration = configuration;
            Size = size;
        }
    }
}