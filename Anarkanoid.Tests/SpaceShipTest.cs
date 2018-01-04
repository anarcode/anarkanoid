using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using System;
using Anarkanoid.Core;
using Anarkanoid.GameComponents;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Tests
{
    [TestClass]
    public class SpaceShipTest
    {
        [TestMethod]
        public void IfIGoVeryFastToTheLeftICantGoMoreFarThanTheSpace()
        {
            IGameConfiguration configuration = new BasicGameConfiguration(90, null);
            SpaceShip spaceShip = new SpaceShip(configuration, new Size(10, 10));
            spaceShip.Position = new Vector2(2, 0);
            spaceShip.Speed = new Vector2(-3, 0);
            spaceShip.Move();

            Assert.AreEqual(0, spaceShip.Position.X);

            spaceShip.Move();

            Assert.AreEqual(spaceShip.Speed.X, spaceShip.Position.X);
        }

        [TestMethod]
        public void IfIGoVeryFastToTheRightICantGoMoreFarThanTheSpace()
        {
            int screenWidth = 100, spaceShipWidth = 10;
            IGameConfiguration configuration = new BasicGameConfiguration(90, null);
            SpaceShip spaceShip = new SpaceShip(configuration, new Size(spaceShipWidth, 10));
            spaceShip.Position = new Vector2(89, 0);
            spaceShip.Speed = new Vector2(3, 0);
            spaceShip.Move();

            Assert.AreEqual(screenWidth - spaceShipWidth, spaceShip.Position.X);

            spaceShip.Move();

            Assert.AreEqual(spaceShip.Speed.X, (float)Math.Round(screenWidth - spaceShipWidth - spaceShip.Position.X, 2) * -1);
        }
    }
}