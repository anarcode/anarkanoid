using Anarkanoid.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Anarkanoid.Core
{
    public partial class RegionManager : IBlockObserver
    {
        Dictionary<Region, List<IBlock>> _blocksByRegion;

        bool IsPointInRegion(Vector2 point, Region region)
        {
            return point.X >= region.Position.X && point.X <= region.Position.X + region.Size.Width &&
                point.Y >= region.Position.Y && point.Y <= region.Position.Y + region.Size.Height;
        }

        public RegionManager(RegionManagerConfiguration configuration, IEnumerable<IBlock> blocks)
        {
            _blocksByRegion = new Dictionary<Region, List<IBlock>>();
            var regionWidth = configuration.TotalSize.Width / configuration.Columns;
            var regionHeight = configuration.TotalSize.Height / configuration.Rows;

            for(var i = 0; i < configuration.Columns; i++)
            {
                for (var j = 0; j < configuration.Rows; j++)
                {
                    var region = new Region { Position = new Vector2(i * regionWidth, j * regionHeight), Size = new Size(regionWidth, regionHeight) };
                    List<IBlock> blocksInRegion = new List<IBlock>();
                    foreach (IBlock block in blocks)
                    {
                        var blockCorners = new List<Vector2>
                        {
                            new Vector2(block.Position.X, block.Position.Y),
                            new Vector2(block.Position.X + block.Size.Width, block.Position.Y),
                            new Vector2(block.Position.X + block.Size.Width, block.Position.Y + block.Size.Height),
                            new Vector2(block.Position.X, block.Position.Y + block.Size.Height)
                        };

                        bool blockInRegion = false;
                        int cornerCounter = 0;
                        while (!blockInRegion && cornerCounter < blockCorners.Count)
                        {
                            blockInRegion = IsPointInRegion(blockCorners[cornerCounter++], region);
                        }

                        if (blockInRegion)
                        {
                            block.AddObserver(this);
                            blocksInRegion.Add(block);
                        }
                    }
                    _blocksByRegion.Add(region, blocksInRegion);
                }
            }
        }

        public IEnumerable<IBlock> GetBlocksByRegion(Vector2 position)
        {
            foreach(Region region in _blocksByRegion.Keys)
            {
                if(IsPointInRegion(position, region))
                {
                    return _blocksByRegion[region];
                }
            }

            return null;
        }

        public void NotifyExplosion(IBlock observable)
        {
            foreach(List<IBlock> blockList in _blocksByRegion.Values)
            {
                if (blockList.Contains(observable))
                {
                    blockList.Remove(observable);
                }
            }
        }
    }
}