using System;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Commands
{
    public class CommandsFactory
    {
        IAnarkanoidGame _arkanoidGame;

        public CommandsFactory(IAnarkanoidGame arkanoidGame)
        {
            _arkanoidGame = arkanoidGame;
        }

        public ICommand GetMoveSpaceShipToLeftCommand()
        {
            return new MoveSpaceShipToLeftCommand(_arkanoidGame);
        }

        public ICommand GetMoveSpaceShipToRightCommand()
        {
            return new MoveSpaceShipToRightCommand(_arkanoidGame);
        }

        public ICommand GetUnhookBallCommand()
        {
            return new UnhookBallCommand(_arkanoidGame);
        }

        public ICommand GetActionCommand(Action action)
        {
            return new ActionCommand(_arkanoidGame, action);
        }

        public ICommand GetDelayedActionCommand(Action action, int milliseconds)
        {
            return new DelayedActionCommand(_arkanoidGame, action, milliseconds);
        }
    }
}