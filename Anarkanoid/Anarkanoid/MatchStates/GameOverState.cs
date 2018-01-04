using Anarkanoid.Core;
using Anarkanoid.GameComponents;
using Anarkanoid.Interfaces;

namespace Anarkanoid.MatchStates
{
    public class GameOverState : MatchState
    {
        const string DIE_TEXT = "YOU FUKING DIE, BITCH!!! Insert coin... or press left key";

        bool _userWantsMore;
        IGameComponent _text;

        public GameOverState(IAnarkanoidGame arkanoidGame, IKeysConfiguration keysConfiguration) : base(arkanoidGame, keysConfiguration)
        {
            _text = new ShowText(Configuration, new Size(Configuration.ScreenSize.Width, Configuration.ScreenSize.Height));
            AnarkanoidGame.ComponentManager.AddText(_text, DIE_TEXT);

            CommandPerKey.Add(Keys.Left, CommandsFactory.GetActionCommand(NewMatch));
        }

        void NewMatch()
        {
            _userWantsMore = true;
        }

        protected override MatchState Update()
        {
            if (_userWantsMore)
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