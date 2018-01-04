using System;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.Commands
{
    public class VoidCommand : Command
    {
        public VoidCommand(IAnarkanoidGame arkanoidGame) : base(arkanoidGame)
        {
        }

        protected override void ExecuteCommand()
        {
        }
    }
}