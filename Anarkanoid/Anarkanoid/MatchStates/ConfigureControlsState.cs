using Anarkanoid.Core;
using Anarkanoid.Interfaces;
using System.Collections.Generic;
using Anarkanoid.GameComponents;
using Microsoft.Xna.Framework.Input;

namespace Anarkanoid.MatchStates
{
    public partial class ConfigureControlsState : MatchState
    {
        List<IGameComponent> _texts;
        int _currentKeyIndex = 0;
        bool _userWantsExit, _changingKey;

        delegate void ChangeKey(Keys key);

        public ConfigureControlsState(IAnarkanoidGame arkanoidGame, IKeysConfiguration keys) : base(arkanoidGame, keys)
        {
            KeyDelay = KEY_DELAY;
            TOTAL_OPTIONS = OPTIONS_TEXTS.Length;
            _texts = new List<IGameComponent>();
            KEYS = new List<Keys>()
            {
                Keys.Left,
                Keys.Right,
                Keys.Shoot
            };

            KEYS_ACTIONS = new List<ChangeKey>()
            {
                ChangeLeftControl,
                ChangeRightControl,
                ChangeShootControl
            };

            var textTopPosition = FIRST_OPTION_TEXT_POSITION.Y;
            for(int i = 0; i < OPTIONS_TEXTS.Length; i++)
            {
                string optionText = OPTIONS_TEXTS[i];
                var text = new ShowText(AnarkanoidGame.ComponentManager.Configuration, OPTION_TEXT_SIZE)
                {
                    Position = new Microsoft.Xna.Framework.Vector2(FIRST_OPTION_TEXT_POSITION.X, textTopPosition),
                    SpriteColor = i == 0 ? SELECTED_TEXT_COLOR : TEXT_COLOR
                };

                if(i == OPTIONS_TEXTS.Length - 1)
                {
                    AnarkanoidGame.ComponentManager.AddText(text, optionText);
                }
                else
                {
                    AnarkanoidGame.ComponentManager.AddText(text, string.Format(TEXT_KEY_TEXT_FORMAT, optionText.PadRight(15), KEYS[i].ToString().PadLeft(15)));
                }
                
                _texts.Add(text);
                textTopPosition += text.Size.Height;
            }

            CommandPerKey.Add(Keys.Down, CommandsFactory.GetActionCommand(NextKeyConfiguration));
            CommandPerKey.Add(Keys.Up, CommandsFactory.GetActionCommand(PreviousKeyConfiguration));
            CommandPerKey.Add(Keys.Enter, CommandsFactory.GetActionCommand(SelectedOption));
        }

        protected override MatchState Update()
        {
            if (!_userWantsExit)
            {
                return this;
            }
            else
            {
                AnarkanoidGame.ComponentManager.Clear();
                return new IntroGameState(AnarkanoidGame, Keys);
            }
        }

        protected override void KeyPressed(Keys key)
        {
            if (_changingKey && (KEYS[_currentKeyIndex] == key || !KEYS.Contains(key))) //Faltan las invisibles
            {
                _changingKey = false;
                KEYS_ACTIONS[_currentKeyIndex](key);
                var text = _texts[_currentKeyIndex];
                AnarkanoidGame.ComponentManager.Remove(_texts[_currentKeyIndex]);
                KEYS[_currentKeyIndex] = key;
                AnarkanoidGame.ComponentManager.AddText(text, string.Format(TEXT_KEY_TEXT_FORMAT, OPTIONS_TEXTS[_currentKeyIndex].PadRight(15), KEYS[_currentKeyIndex].ToString().PadLeft(15)));
            }
        }
    }
}