using Microsoft.Xna.Framework;
using Anarkanoid.Core;

namespace Anarkanoid.Interfaces
{
    public interface IGameComponent
    {
        Vector2 Scale { get; set; }

        Color SpriteColor { get; set; }

        Size Size { get; set; }

        Vector2 Position { get; set; }
    }
}