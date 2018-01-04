using Microsoft.Xna.Framework.Input;

namespace Anarkanoid.MatchStates
{
    public partial class ConfigureControlsState : MatchState
    {
        void PreviousKeyConfiguration()
        {
            if (!_changingKey)
            {
                _texts[_currentKeyIndex].SpriteColor = TEXT_COLOR;

                _currentKeyIndex--;
                if (_currentKeyIndex < 0)
                {
                    _currentKeyIndex = OPTIONS_TEXTS.Length - 1;
                }

                _texts[_currentKeyIndex].SpriteColor = SELECTED_TEXT_COLOR;
            }
        }

        void NextKeyConfiguration()
        {
            if (!_changingKey)
            {
                _texts[_currentKeyIndex].SpriteColor = TEXT_COLOR;

                _currentKeyIndex++;
                if (_currentKeyIndex == OPTIONS_TEXTS.Length)
                {
                    _currentKeyIndex = 0;
                }

                _texts[_currentKeyIndex].SpriteColor = SELECTED_TEXT_COLOR;
            }
        }

        void SelectedOption()
        {
            if (_currentKeyIndex == OPTIONS_TEXTS.Length - 1)
            {
                _userWantsExit = true;
            }
            else
            {
                _changingKey = true;
                var text = _texts[_currentKeyIndex];
                AnarkanoidGame.ComponentManager.Remove(_texts[_currentKeyIndex]);
                AnarkanoidGame.ComponentManager.AddText(text, PRESS_KEY_TEXT);
                CurrentKeyPressed = Microsoft.Xna.Framework.Input.Keys.Enter; //No sé si hace falta
            }
        }

        void ChangeLeftControl(Keys key)
        {
            Keys.Left = key;
        }

        void ChangeRightControl(Keys key)
        {
            Keys.Right = key;
        }

        void ChangeShootControl(Keys key)
        {
            Keys.Shoot = key;
        }
    }
}