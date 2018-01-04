using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Anarkanoid.Core
{
    public class BoardDefinition
    {
        protected List<BlockDefinition> _blocks, _irromptableBlocks;

        public IEnumerable<BlockDefinition> BloksDefinition
        {
            get { return _blocks; }
        }

        public IEnumerable<BlockDefinition> IrromptableBlocksDefinition
        {
            get { return _irromptableBlocks; }
        }

        public BoardDefinition(string fileName)
        {
            _blocks = new List<BlockDefinition>();
            _irromptableBlocks = new List<BlockDefinition>();

            var blockDefinitions = File.ReadAllLines(fileName);
            if(blockDefinitions.Length > 0)
            {
                foreach(string blockDefinition in blockDefinitions)
                {
                    var components = blockDefinition.Split(',');
                    if(components.Length == 3)
                    {
                        int x, y;
                        BlockType blockType;
                        if(int.TryParse(components[0], out x) && 
                            int.TryParse(components[1], out y) && 
                            Enum.TryParse<BlockType>(components[2], out blockType))
                        {
                            if(blockType == BlockType.Irromptable)
                            {
                                _irromptableBlocks.Add(new BlockDefinition { Position = new Vector2(x, y), Type = blockType });
                            }
                            else
                            {
                                _blocks.Add(new BlockDefinition { Position = new Vector2(x, y), Type = blockType });
                            }
                        }
                    }
                }
            }
        }
    }
}