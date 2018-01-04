using Anarkanoid.Core;
using Anarkanoid.GameComponents;
using Anarkanoid.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Anarkanoid.MatchStates
{
    public partial class IntroGameState : MatchState
    {
        //Aleatoriamente tengo que decirle lo de Press space. One more time. Now say "cancamusa". Do it. Really. Really?

        CustomElement _background, _spaceInvader;
        List<ShowText> _optionsText;
        MatchState _returnState;
        int _currentOption;

        public IntroGameState(IAnarkanoidGame anarkanoidGame, IKeysConfiguration keys) : base(anarkanoidGame, keys)
        {
            KeyDelay = KEY_DELAY;
            TOTAL_OPTIONS = OPTIONS_TEXTS.Length;
            AnarkanoidGame.CurrentStage = 0;

            var backgroundSize = new Size(
                AnarkanoidGame.ComponentManager.Configuration.ScreenSize.Width,
                AnarkanoidGame.ComponentManager.Configuration.ScreenSize.Height
            );
            _background = new CustomElement(AnarkanoidGame.ComponentManager.Configuration, backgroundSize)
            {
                Scale = new Vector2(BACKGROUND_SCALE, BACKGROUND_SCALE)
            };
            AnarkanoidGame.ComponentManager.AddComponentByAssetName(_background, "Title");

            var spaceInvaderSize = new Size(
                AnarkanoidGame.ComponentManager.Configuration.ScreenSize.Width / SPACE_INVADER_PERCENT_SCALE,
                AnarkanoidGame.ComponentManager.Configuration.ScreenSize.Height / SPACE_INVADER_PERCENT_SCALE
            );
            _spaceInvader = new CustomElement(AnarkanoidGame.ComponentManager.Configuration, spaceInvaderSize)
            {
                Position = SPACE_INVADER_POSITION
            };
            AnarkanoidGame.ComponentManager.AddComponentByAssetName(_spaceInvader, "SpaceInvader");

            var subtitle = new ShowText(AnarkanoidGame.ComponentManager.Configuration, OPTION_TEXT_SIZE)
            {
                Position = SUBTITLE_POSITION,
                SpriteColor = Color.Red,
                Scale = new Vector2(1.5f, 1.5f)
            };
            AnarkanoidGame.ComponentManager.AddText(subtitle, SUBTITLE_TEXT);

            //SUBTITLE_TEXT

            var textTopPosition = FIRST_OPTION_TEXT_POSITION.Y;
            _optionsText = new List<ShowText>();
            foreach (string optionText in OPTIONS_TEXTS)
            {
                var text = new ShowText(AnarkanoidGame.ComponentManager.Configuration, OPTION_TEXT_SIZE)
                {
                    Position = new Vector2(FIRST_OPTION_TEXT_POSITION.X, textTopPosition),
                    SpriteColor = Color.Black
                };
                AnarkanoidGame.ComponentManager.AddText(text, optionText);
                _optionsText.Add(text);
                textTopPosition += text.Size.Height;
            }

            ACTIONS = new System.Action[]
            {
                NewGameSelected, ConfigureControlsSelected, ToggleFullScreenSelected, ExitGameSelected
            };

            AnarkanoidGame.ComponentManager.SpaceShip.Scale = new Vector2(.8f, .8f);
            AnarkanoidGame.ComponentManager.SpaceShip.Position = new Vector2(
                _optionsText[0].Position.X - AnarkanoidGame.ComponentManager.SpaceShip.Size.Width,
                _optionsText[0].Position.Y + 10
            );
            AnarkanoidGame.ComponentManager.AddSpaceShip(AnarkanoidGame.ComponentManager.SpaceShip);

            CommandsFactory.GetDelayedActionCommand(ToggleSpceInvaderPosition, 1000).Execute();

            CommandPerKey.Add(Keys.Up, CommandsFactory.GetActionCommand(MoveUpOption));
            CommandPerKey.Add(Keys.Down, CommandsFactory.GetActionCommand(MoveDownOption));
            CommandPerKey.Add(Microsoft.Xna.Framework.Input.Keys.Enter, CommandsFactory.GetActionCommand(EnterPressed));

            _returnState = this;

            AnarkanoidGame.ComponentManager.PlaySound("Anarky");
        }

        void ToggleSpceInvaderPosition()
        {
            if(_spaceInvader.Position.X == SPACE_INVADER_POSITION.X)
            {
                _spaceInvader.Position = new Vector2(_spaceInvader.Position.X + 150, _spaceInvader.Position.Y);
            }
            else
            {
                _spaceInvader.Position = new Vector2(_spaceInvader.Position.X - 150, _spaceInvader.Position.Y);
            }
            CommandsFactory.GetDelayedActionCommand(ToggleSpceInvaderPosition, 1000).Execute();
        }

        protected override MatchState Update()
        {
            return _returnState;
        }
    }
}