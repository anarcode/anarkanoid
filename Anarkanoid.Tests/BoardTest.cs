using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Anarkanoid.Core;
using Anarkanoid.GameComponents;
using System.Collections.Generic;
using Anarkanoid.GameComponents.Blocks;
using Anarkanoid.Interfaces;
using Anarkanoid.GameComponents.Balls;

namespace Anarkanoid.Tests
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void IFindCollisions()
        {
            var configuration = new BasicGameConfiguration(0, null);
            var blocks = new List<IBlock>()
            {
                new BasicBlock(configuration, new Size(64, 32)) { Position = new Vector2(5, 5) }
            };
            var ball = new BasicBall(configuration, new Size(5, 5)) { Position = new Vector2(15, 26.15f), Speed = new Vector2(0, -2) };
            var board = new Board(blocks, null, new Size(100, 100), ball.Size.Width * ball.Scale.X);
            var block = board.Collides(ball);
        }
    }
}