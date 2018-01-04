using Microsoft.Xna.Framework;
using Anarkanoid.Core;

namespace Anarkanoid.Boards
{
    public class ThreeBallsStage : BoardDefinition
    {
        public ThreeBallsStage() : base()
        {
            for (int i = 0; i < 12; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    _blocks.Add(new BlockDefinition { Position = new Vector2(i * 50 + 110, 150 + j * 32), Type = BlockType.ThreeBallsPrize });
                }
            }
        }
    }
}