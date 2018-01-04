using Microsoft.Xna.Framework.Input;

namespace Anarkanoid.Core
{
    public interface IKeysConfiguration //struct??
    {
        Keys Exit { get; set; }

        Keys NewGame { get; set; }

        Keys Left { get; set; }

        Keys Right { get; set; }

        Keys Shoot { get; set; }

        Keys Enter { get; set; }

        Keys Up { get; set; }

        Keys Down { get; set; }

        Keys AddBlock { get; set; }

        Keys RemoveBlock { get; set; }

        Keys IncrementBlockMoveStep { get; set; }

        Keys DecrementBlockMoveStep { get; set; }
    }
}