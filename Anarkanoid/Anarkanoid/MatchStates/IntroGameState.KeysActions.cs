using Microsoft.Xna.Framework;

namespace Anarkanoid.MatchStates
{
    public partial class IntroGameState
    {
        void MoveSpaceShipToOption()
        {
            var spaceShip = AnarkanoidGame.ComponentManager.SpaceShip;
            spaceShip.Position = new Vector2(
                _optionsText[_currentOption].Position.X - spaceShip.Size.Width,
                _optionsText[_currentOption].Position.Y + 10
            );
        }

        void MoveDownOption()
        {
            if (_currentOption == TOTAL_OPTIONS - 1)
            {
                _currentOption = 0;
            }
            else
            {
                _currentOption++;
            }
            MoveSpaceShipToOption();
        }

        void MoveUpOption()
        {
            var spaceShip = AnarkanoidGame.ComponentManager.SpaceShip;
            if (_currentOption == 0)
            {
                _currentOption = TOTAL_OPTIONS - 1;
            }
            else
            {
                _currentOption--;
            }
            MoveSpaceShipToOption();
        }

        void NewGameSelected()
        {
            AnarkanoidGame.ComponentManager.Clear();
            _returnState = new IntroMatchState(AnarkanoidGame, Keys);
            AnarkanoidGame.ComponentManager.StopSound();
        }

        void ConfigureControlsSelected()
        {
            AnarkanoidGame.ComponentManager.Clear();
            _returnState = new ConfigureControlsState(AnarkanoidGame, Keys);
        }

        void ToggleFullScreenSelected()
        {
            AnarkanoidGame.ToggleFullScreen();
        }

        void ExitGameSelected()
        {
            AnarkanoidGame.ExitGame();
        }

        void EnterPressed()
        {
            ACTIONS[_currentOption]();
        }
    }
}