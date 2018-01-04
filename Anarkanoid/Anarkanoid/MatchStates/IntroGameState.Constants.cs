using Microsoft.Xna.Framework;
using Anarkanoid.Core;
using System;

namespace Anarkanoid.MatchStates
{
    public partial class IntroGameState
    {
        const string SUBTITLE_TEXT = "The secular humanist";
        readonly Vector2 SUBTITLE_POSITION = new Vector2(420, 332);
        const string ONE_PLAYER_TEXT = "One player";
        const string CONFIGURE_CONTROLS_TEXT = "Configure controls";
        const string TOGGLEFULLSCREEN_TEXT = "Toggle fullscreen";
        const string EXIT_TEXT = "Please, exit";

        readonly string[] OPTIONS_TEXTS = new string[] { ONE_PLAYER_TEXT, CONFIGURE_CONTROLS_TEXT, TOGGLEFULLSCREEN_TEXT, EXIT_TEXT };
        readonly Vector2 FIRST_OPTION_TEXT_POSITION = new Vector2(300, 400);
        readonly Size OPTION_TEXT_SIZE = new Size(100, 20);
        readonly int TOTAL_OPTIONS;

        const int KEY_DELAY = 300;
        const float BACKGROUND_SCALE = .8f;
        const int SPACE_INVADER_PERCENT_SCALE = 10;
        readonly Vector2 SPACE_INVADER_POSITION = new Vector2(50, 10);
        readonly Action[] ACTIONS;
    }
}