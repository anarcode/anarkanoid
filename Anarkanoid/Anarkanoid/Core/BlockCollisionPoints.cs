using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Anarkanoid.Core
{
    public class BlockCollisionPoints
    {
        public List<Vector2> LeftCollisionPoints { get; private set; }

        public List<Vector2> TopCollisionPoints { get; private set; }

        public List<Vector2> RightCollisionPoints { get; private set; }

        public List<Vector2> BottomCollisionPoints { get; private set; }

        public BlockCollisionPoints(
            List<Vector2> leftCollisionPoints,
            List<Vector2> topCollisionPoints,
            List<Vector2> rightCollisionPoints,
            List<Vector2> bottomCollisionPoints)
        {
            LeftCollisionPoints = leftCollisionPoints;
            TopCollisionPoints = topCollisionPoints;
            RightCollisionPoints = rightCollisionPoints;
            BottomCollisionPoints = bottomCollisionPoints;
        }
    }
}