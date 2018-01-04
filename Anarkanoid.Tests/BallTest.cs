using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using System;
using Anarkanoid.Core;
using Anarkanoid.GameComponents.Balls;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Tests
{
    [TestClass]
    public class BasicBallTest
    {
        [TestMethod]
        public void IfIGoVeryFastToTheLeftICantGoMoreFarThanTheSpace()
        {
            int speed = 4;
            IGameConfiguration configuration = new BasicGameConfiguration(42, null);
            BasicBall ball = new BasicBall(configuration, new Size(42, 42));
            ball.Position = new Vector2(speed - 1, 42);
            ball.Speed = new Vector2(speed * -1, 42);
            ball.Move();

            Assert.AreEqual(0, ball.Position.X);

            ball.Move();

            Assert.AreEqual(ball.Speed.X, ball.Position.X);
        }

        [TestMethod]
        public void IfIGoVeryFastToTheRightICantGoMoreFarThanTheSpace()
        {
            int screenWidth = 800, ballWidth = 21, speed = 4;
            int roundErrorForBallScaleFloatValue = 1;
            IGameConfiguration configuration = new BasicGameConfiguration(42, null);
            BasicBall ball = new BasicBall(configuration, new Size(ballWidth, 42));
            ball.Position = new Vector2(screenWidth - ballWidth - speed + 1, 42);
            ball.Speed = new Vector2(speed, 42);
            ball.Move();

            Assert.AreEqual(screenWidth - ballWidth, ball.Position.X - roundErrorForBallScaleFloatValue);

            ball.Move();

            Assert.AreEqual(ball.Speed.X, (float)Math.Round(screenWidth - ballWidth - ball.Position.X, 2) * -1 - roundErrorForBallScaleFloatValue);
        }

        [TestMethod]
        public void IfIGoUpVeryFastICantGoMoreFarThanTheSpace()
        {
            IGameConfiguration configuration = new BasicGameConfiguration(42, null);
            BasicBall ball = new BasicBall(configuration, new Size(42, 42));
            ball.Position = new Vector2(42, 3);
            ball.Speed = new Vector2(42, -4);
            ball.Move();

            Assert.AreEqual(0, ball.Position.Y);

            ball.Move();

            Assert.AreEqual(ball.Speed.Y, ball.Position.Y);
        }

        //[TestMethod]
        //public void IfIGoDownVeryFastICantGoMoreFarThanTheSpace()
        //{
        //    int screenHeight = 480, ballHeight = 21, randomNumber = 26;
        //    //int roundErrorForBallScaleFloatValue = 1;
        //    IGameConfiguration configuration = new BasicGameConfiguration(new Size(42, screenHeight), screenHeight - randomNumber, null);
        //    Ball ball = new Ball(configuration, new Size(42, ballHeight));
        //    ball.Position = new Vector2(42, screenHeight - randomNumber - ballHeight - 1);
        //    ball.Speed = new Vector2(0, 2);
        //    ball.Move();

        //    //Assert.IsTrue(ball.IsOnMaximumBottomPosition);
        //    //Assert.AreEqual(screenHeight - randomNumber - ballHeight, ball.Position.Y - roundErrorForBallScaleFloatValue);

        //    ball.Move();

        //    Assert.AreEqual(ball.Speed.Y, (float)Math.Round(screenHeight - randomNumber - ballHeight - ball.Position.Y, 2));
        //}
    }
}