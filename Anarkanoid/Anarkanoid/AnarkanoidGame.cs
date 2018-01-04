using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;
using Anarkanoid.MatchStates;

namespace Anarkanoid
{
    public class AnarkanoidGame : Game, IAnarkanoidGame
    {
        GraphicsDeviceManager _graphics;
        MatchState _state;

        public IComponentManager ComponentManager { get; private set; }

        public int CurrentLives { get; set; }

        public int CurrentStage { get; set; }

        public AnarkanoidGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            ComponentManager = new ComponentManager(Content, _graphics);
            _state = new IntroGameState(this, new BasicKeysConfiguration());
        }

        public void ExitGame()
        {
            Exit();
        }

        public void ToggleFullScreen()
        {
            _graphics.IsFullScreen = !_graphics.IsFullScreen;
            _graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            _state = _state.Update(Keyboard.GetState(PlayerIndex.One));
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            ComponentManager.Draw();
            base.Draw(gameTime);
        }
    }
}