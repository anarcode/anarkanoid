using Anarkanoid.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Anarkanoid.MatchStates
{
    public partial class ConfigureControlsState : MatchState
    {
        const string LEFT_CONTROL_TEXT = "Left";
        const string RIGHT_CONTROL_TEXT = "Right";
        const string SHOOT_CONTROL_TEXT = "Shoot";
        const string EXIT_TEXT = "Go back";
        const string TEXT_KEY_TEXT_FORMAT = "{0}-->{1}";
        const string PRESS_KEY_TEXT = "Press the key that pops out of your balls";
        readonly Color TEXT_COLOR = Color.White;
        readonly Color SELECTED_TEXT_COLOR = Color.Red;

        readonly string[] OPTIONS_TEXTS = new string[] { LEFT_CONTROL_TEXT, RIGHT_CONTROL_TEXT, SHOOT_CONTROL_TEXT, EXIT_TEXT };
        readonly Vector2 FIRST_OPTION_TEXT_POSITION = new Vector2(100, 100);
        readonly Size OPTION_TEXT_SIZE = new Size(100, 20);
        readonly int TOTAL_OPTIONS;

        readonly List<ChangeKey> KEYS_ACTIONS;
        readonly List<Keys> KEYS;
        const int KEY_DELAY = 500;
    }
}