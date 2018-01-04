using Microsoft.Xna.Framework;
using Anarkanoid.Core;
using System.Collections.Generic;

namespace Anarkanoid.Boards
{
    public class FirstStage : BoardDefinition
    {
        public FirstStage() : base()
        {
            //Tengo que hacer que la primera pantalla no haya que moverse solo darle al espacio y luego
            //well done, You complete the tutorial

            List<Vector2> irromptableBlocksPositions = new List<Vector2>();
            List<Vector2> normalBlocks = new List<Vector2>();

            for (int i = 0; i < 15; i++)
            {
                irromptableBlocksPositions.Add(new Vector2(i * 48, 100));
                irromptableBlocksPositions.Add(new Vector2(i * 48, 300));
                normalBlocks.Add(new Vector2(i * 44, 150));
                normalBlocks.Add(new Vector2(i * 44, 350));
            }

            for (int i = 0; i < 15; i++)
            {
                irromptableBlocksPositions.Add(new Vector2(i * 48 + 140, 200));
                normalBlocks.Add(new Vector2(i * 44 + 140, 250));
            }

            foreach (Vector2 position in irromptableBlocksPositions)
            {
                _irromptableBlocks.Add(new BlockDefinition { Position = position, Type = BlockType.Irromptable });
            }

            foreach (Vector2 position in normalBlocks)
            {
                _blocks.Add(new BlockDefinition { Position = position, Type = BlockType.ThreeBallsPrize });
            }



            //for (int i = 0; i < 12; i++)
            //{
            //    for(int j = 0; j < 6; j++)
            //    {

            //    }
            //}
        }
    }
}