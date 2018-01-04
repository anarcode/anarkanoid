using Microsoft.Xna.Framework;
using Anarkanoid.Core;
using Anarkanoid.GameComponents;
using Anarkanoid.Interfaces;

namespace Anarkanoid.MatchStates
{
    public class WinGameState : MatchState
    {
        const string YOU_DID_IT_TEXT = "YOU DID IT, BITCH!!!\r\nYou conquered 42\r\nPress shoot to return intro";

        bool _userWantsMore;

        public WinGameState(IAnarkanoidGame arkanoidGame, IKeysConfiguration keysConfiguration) : base(arkanoidGame, keysConfiguration)
        {
            var textComponent = new ShowText(Configuration, new Size(Configuration.ScreenSize.Width, Configuration.ScreenSize.Height))
            {
                Position = new Vector2(200, 200)
            };
            AnarkanoidGame.ComponentManager.AddText(textComponent, YOU_DID_IT_TEXT);

            Components.SpaceShip.Reset();
            AnarkanoidGame.ComponentManager.AddSpaceShip(AnarkanoidGame.ComponentManager.SpaceShip);

            CommandPerKey.Add(Keys.Left, CommandsFactory.GetMoveSpaceShipToLeftCommand());
            CommandPerKey.Add(Keys.Right, CommandsFactory.GetMoveSpaceShipToRightCommand());
            CommandPerKey.Add(Keys.Shoot, CommandsFactory.GetActionCommand(UserWantsMore));
        }
        
        void UserWantsMore()
        {
            _userWantsMore = true;
        }

        protected override MatchState Update()
        {
            Components.SpaceShip.Move();
            if (_userWantsMore)
            {
                AnarkanoidGame.ComponentManager.Clear();
                return new IntroGameState(AnarkanoidGame, Keys);
            }
            else
            {
                return this;
            }
        }
    }
}