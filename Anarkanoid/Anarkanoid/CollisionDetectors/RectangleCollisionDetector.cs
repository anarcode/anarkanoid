using Microsoft.Xna.Framework;
using System;

namespace Anarkanoid.CollisionDetectors
{
    public abstract class RectangleCollisionDetector
    {
        protected bool Collides(Interfaces.IGameComponent gameComponent1, Interfaces.IGameComponent gameComponent2)
        {
            int x1 = Convert.ToInt32(gameComponent1.Position.X), 
               y1 = Convert.ToInt32(gameComponent1.Position.Y),
               width = Convert.ToInt32(gameComponent1.Size.Width * gameComponent1.Scale.X),
               height = Convert.ToInt32(gameComponent1.Size.Height * gameComponent1.Scale.Y);
            Rectangle rectangle1 = new Rectangle(x1, y1, width, height);

            x1 = Convert.ToInt32(gameComponent2.Position.X);
            y1 = Convert.ToInt32(gameComponent2.Position.Y);
            width = Convert.ToInt32(gameComponent2.Size.Width * gameComponent2.Scale.X);
            height = Convert.ToInt32(gameComponent2.Size.Height * gameComponent2.Scale.Y);
            Rectangle rectangle2 = new Rectangle(x1, y1, width, height);
            
            return rectangle1.Intersects(rectangle2);
        }
    }
}