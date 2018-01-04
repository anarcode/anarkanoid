using Anarkanoid.Core;
using Anarkanoid.GameComponents;
using Anarkanoid.Interfaces;
using System.Timers;

namespace Anarkanoid.MatchStates
{
    public class NextStageState : MatchState
    {
        const string TEXT = "Well done, bitch!!";

        IGameComponent _text;
        Timer _timer;
        bool _continue;

        public NextStageState(IAnarkanoidGame arkanoidGame, IKeysConfiguration keys) : base(arkanoidGame, keys)
        {
            _text = new ShowText(Configuration, new Size(Configuration.ScreenSize.Width, Configuration.ScreenSize.Height))
            {
                Position = new Microsoft.Xna.Framework.Vector2(150, 150)
            };
            AnarkanoidGame.ComponentManager.AddText(_text, TEXT);

            _timer = new Timer(5000);
            _timer.Elapsed += ((o, e) => _continue = true);
            _timer.Start();
        }

        protected override MatchState Update()
        {
            if (_continue)
            {
                AnarkanoidGame.ComponentManager.RemoveBalls();
                if(AnarkanoidGame.CurrentStage > AnarkanoidGame.ComponentManager.Configuration.Boards.Count)
                {
                    return new IntroGameState(AnarkanoidGame, Keys);
                }
                else
                {
                    return new NewMatchState(AnarkanoidGame, Keys);
                }
            }
            else
            {
                return this;
            }
        }
    }
}