using Microsoft.Xna.Framework;

namespace Anarkanoid.Interfaces
{
    public interface IMobileGameComponent : IGameComponent
    {
        Vector2 Speed { get; set; }

        void Move();

        void Reset();
    }
}