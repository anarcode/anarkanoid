using Anarkanoid.Core;
using Anarkanoid.GameComponents;
using Anarkanoid.Interfaces;

namespace Anarkanoid.MatchStates
{
    public class IntroMatchState : MatchState
    {
        const string TEXT = "Hello human, you are selected for representing human race against \r\nother species (or things). Press Enter to start...";
        const string FIRST_STEP_JOKE_TEXT = "Or space.";
        const string SECOND_STEP_JOKE_TEXT = "Or space. Yes.";
        const string THIRD_STEP_JOKE_TEXT = "Or space. Yes. Better press space...";
        const int TOTAL_STEPS = 3;
        readonly string[] JOKE_TEXTS = new string[] { FIRST_STEP_JOKE_TEXT, SECOND_STEP_JOKE_TEXT, THIRD_STEP_JOKE_TEXT };
        int _jokeStep;
        bool _userWantsToPlay;
        IGameComponent _text;

        public IntroMatchState(IAnarkanoidGame arkanoidGame, IKeysConfiguration keysConfiguration) : base(arkanoidGame, keysConfiguration)
        {
            KeyDelay = 300;

            _text = new ShowText(Configuration, new Size(Configuration.ScreenSize.Width, Configuration.ScreenSize.Height))
            {
                Position = new Microsoft.Xna.Framework.Vector2(30, 200)
            };
            AnarkanoidGame.ComponentManager.AddText(_text, TEXT);

            KeysEnabled = false;
            CommandPerKey.Add(Keys.Enter, CommandsFactory.GetActionCommand(FirstJoke));
            CommandsFactory.GetDelayedActionCommand(() => KeysEnabled = true, 100).Execute();
        }

        void FirstJoke()
        {
            if(_jokeStep == TOTAL_STEPS)
            {
                if (!CommandPerKey.ContainsKey(Keys.Shoot))
                {
                    CommandPerKey.Add(Keys.Shoot, CommandsFactory.GetActionCommand(NewMatch));
                }
            }
            else
            {
                AnarkanoidGame.ComponentManager.AddText(_text, TEXT + "\r\n" + JOKE_TEXTS[_jokeStep]);
                _jokeStep++;
                CommandsFactory.GetDelayedActionCommand(FirstJoke, 1000).Execute();
            }
        }

        void NewMatch()
        {
            _userWantsToPlay = true;
        }

        protected override MatchState Update()
        {
            if (_userWantsToPlay)
            {
                AnarkanoidGame.ComponentManager.Remove(_text);
                return new NewMatchState(AnarkanoidGame, Keys);
            }
            else
            {
                return this;
            }
        }
    }
}