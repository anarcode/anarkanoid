using Anarkanoid.Interfaces;

namespace Anarkanoid.Core
{
    public abstract class Command : ICommand
    {
        bool _executing;

        protected IAnarkanoidGame ArkanoidGame { get; private set; }

        protected Command(IAnarkanoidGame arkanoidGame)
        {
            ArkanoidGame = arkanoidGame;
        }

        public void Execute()
        {
            if (_executing)
            {
                return;
            }

            _executing = true;
            ExecuteCommand();
            _executing = false;
        }

        protected abstract void ExecuteCommand();
    }
}