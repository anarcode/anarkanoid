using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Anarkanoid.Commands;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;
using System.Timers;

namespace Anarkanoid.MatchStates
{
    public abstract class MatchState
    {
        protected Keys CurrentKeyPressed = Microsoft.Xna.Framework.Input.Keys.None;
        Timer _timer;

        protected IAnarkanoidGame AnarkanoidGame { get; private set; }

        protected IKeysConfiguration Keys { get; private set; }

        protected IGameConfiguration Configuration
        {
            get { return AnarkanoidGame.ComponentManager.Configuration; }
        }

        protected IMatchComponents Components
        {
            get { return AnarkanoidGame.ComponentManager; }
        }

        protected Dictionary<Keys, ICommand> CommandPerKey { get; private set; }

        protected List<Keys> AvailableKeys
        {
            get { return new List<Keys>(CommandPerKey.Keys); }
        }

        protected CommandsFactory CommandsFactory { get; private set; }

        protected bool KeysEnabled { get; set; }

        protected int KeyDelay { get; set; }

        public MatchState(IAnarkanoidGame arkanoidGame, IKeysConfiguration keys)
        {
            AnarkanoidGame = arkanoidGame;
            Keys = keys;
            CommandsFactory = new CommandsFactory(AnarkanoidGame);
            CommandPerKey = new Dictionary<Keys, ICommand>();

            CommandPerKey.Add(Microsoft.Xna.Framework.Input.Keys.None, new VoidCommand(AnarkanoidGame));
            CommandPerKey.Add(keys.Exit, CommandsFactory.GetActionCommand(ExitGame));

            KeysEnabled = true;
            KeyDelay = 1;

            CurrentKeyPressed = Microsoft.Xna.Framework.Input.Keys.Enter;
            _timer = new Timer(1000);
            _timer.Elapsed += (e, s) =>
            {
                CurrentKeyPressed = Microsoft.Xna.Framework.Input.Keys.None;
                _timer.Stop();
            };
            _timer.Start();
        }

        protected ICommand GetCommandForKey(Keys key)
        {
            if (AvailableKeys.Contains(key))
            {
                return CommandPerKey[key];
            }
            else
            {
                return null;
            }
        }

        void ExitGame()
        {
            AnarkanoidGame.ExitGame();
        }

        public MatchState Update(KeyboardState keyboardState)
        {
            if (KeysEnabled)
            {
                foreach (Keys key in AvailableKeys)
                {
                    if (CurrentKeyPressed != key)
                    {
                        if (keyboardState.IsKeyDown(key))
                        {
                            CurrentKeyPressed = key;
                            var commandForKey = GetCommandForKey(key);
                            if (commandForKey != null)
                            {
                                commandForKey.Execute();
                            }
                            _timer = new Timer(KeyDelay);
                            _timer.Elapsed += (e, s) =>
                            {
                                CurrentKeyPressed = Microsoft.Xna.Framework.Input.Keys.None;
                                try
                                {
                                    _timer.Stop();
                                }
                                catch(System.NullReferenceException)
                                { }
                            };
                            _timer.Start();
                        }
                    }
                }
            }

            if(keyboardState.GetPressedKeys().Length > 0 && keyboardState.GetPressedKeys()[0] != CurrentKeyPressed)
            {
                KeyPressed(keyboardState.GetPressedKeys()[0]);
            }
            return Update();
        }

        protected abstract MatchState Update();

        protected virtual void KeyPressed(Keys key)
        {

        }
    }
}