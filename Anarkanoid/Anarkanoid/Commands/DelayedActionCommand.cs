
using System;
using Anarkanoid.Interfaces;
using System.Timers;

namespace Anarkanoid.Commands
{
    public class DelayedActionCommand : ActionCommand
    {
        int _milliseconds;

        public DelayedActionCommand(IAnarkanoidGame arkanoidGame, Action action, int milliseconds) : base(arkanoidGame, action)
        {
            _milliseconds = milliseconds;
        }

        protected override void ExecuteCommand()
        {
            Timer timer = new Timer(_milliseconds);
            timer.Elapsed += (sender, e) =>
            {
                base.ExecuteCommand();
                timer.Enabled = false;
                timer.Dispose();
            };
            timer.Start();
        }
    }
}