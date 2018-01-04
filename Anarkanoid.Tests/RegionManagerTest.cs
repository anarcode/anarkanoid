using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Anarkanoid.Core;
using Anarkanoid.GameComponents;
using System.Collections.Generic;
using Anarkanoid.GameComponents.Blocks;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Tests
{
    [TestClass]
    public class RegionManagerTest
    {
        [TestMethod]
        public void IFoundTheRegion()
        {
            var configuration = new RegionManagerConfiguration()
            {
                Columns = 3,
                Rows = 3,
                TotalSize = new Size(120, 120)
            };
            var blocks = new List<Block>
            {
                new BasicBlock(null, new Size(10, 10)) { Position = new Vector2(15, 15) },
                new BasicBlock(null, new Size(10, 10)) { Position = new Vector2(35, 15) }
            };

            RegionManager regionManager = new RegionManager(configuration, blocks);
            var blocksNear = regionManager.GetBlocksByRegion(new Vector2(15, 5));

            List<IBlock> found = new List<IBlock>(blocksNear);
            Assert.AreEqual(found.Count, 2);
        }
    }
}