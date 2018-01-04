using Anarkanoid.Interfaces;
using Anarkanoid.Core;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Anarkanoid.CollisionDetectors
{
    public class BallBlockCollisionDetector : IBlockCollisionDetector
    {
        Dictionary<IBlock, BlockCollisionPoints> _collisionPoints;
        float _ballDiameter, _ballRadius;

        public BallBlockCollisionDetector(List<IBlock> blocks, float ballDiameter)
        {
            _collisionPoints = new Dictionary<IBlock, BlockCollisionPoints>();
            var collisionPointsCalculator = new BlockCollisionPointsCalculator(ballDiameter);
            foreach (IBlock block in blocks)
            {
                _collisionPoints.Add(block, collisionPointsCalculator.Calculate(block));
            }
            _ballDiameter = ballDiameter;
            _ballRadius = _ballDiameter / 2;
        }

        public BlockCollision Collides(Vector2 position, IBlock block)
        {
            var ballCenter = new Vector2(position.X + _ballRadius, position.Y + _ballRadius);
            var collisionPoints = _collisionPoints[block];
            BlockCollision blockCollision = new BlockCollision() { Collides = true };

            foreach (Vector2 currentCollisionPoints in collisionPoints.LeftCollisionPoints)
            {
                float distance = Vector2.Distance(ballCenter, currentCollisionPoints);
                if (distance <= _ballRadius)
                {
                    blockCollision.Type = BlockCollisionType.Left;
                    return blockCollision;
                }
            }

            foreach (Vector2 currentCollisionPoints in collisionPoints.RightCollisionPoints)
            {
                float distance = Vector2.Distance(ballCenter, currentCollisionPoints);
                if (distance <= _ballRadius)
                {
                    blockCollision.Type = BlockCollisionType.Right;
                    return blockCollision;
                }
            }

            foreach (Vector2 currentCollisionPoints in collisionPoints.TopCollisionPoints)
            {
                float distance = Vector2.Distance(ballCenter, currentCollisionPoints);
                if (distance <= _ballRadius)
                {
                    blockCollision.Type = BlockCollisionType.Top;
                    return blockCollision;
                }
            }

            foreach (Vector2 currentCollisionPoints in collisionPoints.BottomCollisionPoints)
            {
                float distance = Vector2.Distance(ballCenter, currentCollisionPoints);
                if (distance <= _ballRadius)
                {
                    blockCollision.Type = BlockCollisionType.Bottom;
                    return blockCollision;
                }
            }

            blockCollision.Collides = false;
            return blockCollision;
        }
    }
}