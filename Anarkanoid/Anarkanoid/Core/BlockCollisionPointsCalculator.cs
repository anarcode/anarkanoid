using Anarkanoid.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Anarkanoid.Core
{
    public class BlockCollisionPointsCalculator
    {
        float _ballDiameter;

        public BlockCollisionPointsCalculator(float ballDiameter)
        {
            _ballDiameter = ballDiameter / 2;
        }

        public BlockCollisionPoints Calculate(IBlock block)
        {
            List<Vector2> leftCollisionPoints = new List<Vector2>();
            List<Vector2> topCollisionPoints = new List<Vector2>();
            List<Vector2> rightCollisionPoints = new List<Vector2>();
            List<Vector2> bottomCollisionPoints = new List<Vector2>();

            var x1 = block.Position.X;
            var y1 = block.Position.Y;
            var x2 = block.Position.X + block.Size.Width * block.Scale.X;
            var y2 = block.Position.Y + block.Size.Height * block.Scale.Y;

            var variantX = x1;
            while (variantX < x2)
            {
                topCollisionPoints.Add(new Vector2(variantX, y1));
                bottomCollisionPoints.Add(new Vector2(variantX, y2));
                variantX += _ballDiameter;
            }

            topCollisionPoints.Add(new Vector2(x2, y1));
            bottomCollisionPoints.Add(new Vector2(x2, y2));

            var variantY = y1;
            while (variantY < y2)
            {
                leftCollisionPoints.Add(new Vector2(x1, variantY));
                rightCollisionPoints.Add(new Vector2(x2, variantY));
                variantY += _ballDiameter;
            }

            leftCollisionPoints.Add(new Vector2(x1, y2));
            rightCollisionPoints.Add(new Vector2(x2, y2));

            var collisionPoints = new BlockCollisionPoints(leftCollisionPoints, topCollisionPoints, rightCollisionPoints, bottomCollisionPoints);
            return collisionPoints;
        }
    }
}