using Microsoft.Xna.Framework;
using Anarkanoid.Core;

namespace Anarkanoid.Boards
{
    public class SecondStage : BoardDefinition
    {
        public SecondStage() : base()
        {
            for (int i = 0; i <= 16; i++)
            {
                _blocks.Add(new BlockDefinition { Position = new Vector2(i * 45 + 18, 100), Type = BlockType.BasicShooterPrize });
            }
        }
    }
}