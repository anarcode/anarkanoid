using System;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Commands
{
    public class ActionCommand : Command
    {
        Action _action;

        public ActionCommand(IAnarkanoidGame arkanoidGame, Action action) : base(arkanoidGame)
        {
            _action = action;
        }

        protected override void ExecuteCommand()
        {
            _action.Invoke();
        }
    }
}