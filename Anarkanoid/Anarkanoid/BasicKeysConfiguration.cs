using Microsoft.Xna.Framework.Input;
using Anarkanoid.Core;

namespace Anarkanoid
{
    public class BasicKeysConfiguration : IKeysConfiguration
    {
        public Keys Exit
        {
            get { return Keys.Escape; }
            set { }
        }

        public Keys Left { get; set; }

        public Keys NewGame
        {
            get { return Keys.Enter; }
            set { }
        }

        public Keys Right { get; set; }

        public Keys Shoot { get; set; }

        public Keys Enter
        {
            get { return Keys.Enter; }
            set { }
        }

        public Keys Up
        {
            get { return Keys.Up; }
            set { }
        }

        public Keys Down
        {
            get { return Keys.Down; }
            set { }
        }

        public Keys AddBlock
        {
            get { return Keys.A; }
            set { }
        }

        public Keys RemoveBlock
        {
            get { return Keys.R; }
            set { }
        }

        public Keys IncrementBlockMoveStep
        {
            get { return Keys.PageUp; }
            set { }
        }

        public Keys DecrementBlockMoveStep
        {
            get { return Keys.PageDown; }
            set { }
        }

        public BasicKeysConfiguration()
        {
            Left = Keys.Left;
            Right = Keys.Right;
            Shoot = Keys.Space;
        }
    }
}