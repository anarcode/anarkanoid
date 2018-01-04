using Anarkanoid.GameComponents;
using Anarkanoid.GameComponents.Balls;
using Anarkanoid.GameComponents.Blocks;
using Anarkanoid.Interfaces;
using Anarkanoid.Prizes;
using Anarkanoid.Shooters;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace Anarkanoid.Core
{
    public class ComponentManager : IComponentManager
    {
        ContentManager _contentManager;
        Texture2D _spaceShipTexture, _ballTexture;
        ComponentDrawer _drawer;
        ResourceRepository _resourceRepository;
        Song _song;

        public SpriteFont Font { get; private set; }

        public IGameConfiguration Configuration { get; private set; }

        public ISpaceShip SpaceShip { get; private set; }

        public BallRepository BallRepository { get; private set; }

        public List<IBall> Balls { get; private set; }

        public IBoard Board { get; private set; }

        public List<IPrize> Prizes { get; private set; }

        public List<IShoot> Shoots { get; private set; }

        public ComponentManager(ContentManager contentManager, Microsoft.Xna.Framework.GraphicsDeviceManager graphicsDeviceManager)
        {
            _contentManager = contentManager;
            _resourceRepository = new ResourceRepository(new BasicResourceRepositoryConfiguration(), _contentManager);

            Font = _resourceRepository.GetFont();
            _spaceShipTexture = _resourceRepository.GetTextureByType(typeof(SpaceShip));

            var graphicsDevice = graphicsDeviceManager.GraphicsDevice;
            Configuration = new BasicGameConfiguration(
                _spaceShipTexture.Height,
                Font
            );

            graphicsDeviceManager.PreferredBackBufferWidth = Configuration.ScreenSize.Width;
            graphicsDeviceManager.PreferredBackBufferHeight = Configuration.ScreenSize.Height;
            graphicsDeviceManager.ApplyChanges();

            SpaceShip = new SpaceShip(Configuration, new Size(_spaceShipTexture.Width, _spaceShipTexture.Height));
            _ballTexture = _resourceRepository.GetTextureByType(typeof(BasicBall));
            BallRepository = new BallRepository(Configuration, new Size(_ballTexture.Width, _ballTexture.Height));
            
            Balls = new List<IBall>();

            _drawer = new ComponentDrawer(graphicsDevice, Font);

            Prizes = new List<IPrize>();
            Shoots = new List<IShoot>();

            MediaPlayer.Volume = .03f;
        }

        public void AddText(IGameComponent component, string text)
        {
            _drawer.Add(component, text);
        }

        public void LoadBoard(BoardDefinition boardDefinition)
        {
            //Aqui tengo que procesar alguna estructura que me diga los bloques
            //Construyo una lista de bloques ya con los observables, etc y se la enchufo al board
            List<IBlock> blocks = new List<IBlock>();
            List<IBlock> irromptableBlocks = new List<IBlock>();
            var shooterFactory = new ShooterFactory(Configuration, _resourceRepository, SpaceShip);
            var prizeFactory = new PrizeFactory(this, _resourceRepository, shooterFactory);

            BlockBuilder builder = new BlockBuilder(this, prizeFactory);
            builder.Configuration(Configuration);

            foreach (BlockDefinition blockDefinition in boardDefinition.BloksDefinition)
            {
                var block = builder.Position(blockDefinition.Position).Type(blockDefinition.Type).Build();
                AddBlock(block);
                blocks.Add(block);
            }

            foreach (BlockDefinition blockDefinition in boardDefinition.IrromptableBlocksDefinition)
            {
                var block = builder.Position(blockDefinition.Position).Type(blockDefinition.Type).Build();
                AddBlock(block);
                irromptableBlocks.Add(block);
            }

            Board = new Board(blocks, irromptableBlocks, Configuration.ScreenSize, Balls[0].Size.Width * Balls[0].Scale.X); //Y si quiero bolas mas grandes?!?!?!
        }

        public void AddSpaceShip(ISpaceShip spaceShip)
        {
            _drawer.Add(spaceShip, _spaceShipTexture);
        }

        public void AddBall(IBall ball)
        {
            Balls.Add(ball);
            _drawer.Add(ball, _resourceRepository.GetTextureByType(ball.GetType()));
        }

        public void RemoveBall(IBall ball)
        {
            Balls.Remove(ball);
            _drawer.Remove(ball);
        }

        public void RemoveBalls()
        {
            foreach(IBall ball in Balls)
            {
                _drawer.Remove(ball);
            }
            Balls.Clear();
        }

        public void AddPrize(IPrize prize)
        {
            Prizes.Add(prize);
            _drawer.Add(prize, _resourceRepository.GetTextureByType(prize.GetType()));
        }

        public void RemovePrize(IPrize prize)
        {
            if (Prizes.Contains(prize))
            {
                Prizes.Remove(prize);
                _drawer.Remove(prize);
            }
        }

        public void RemovePrizes()
        {
            foreach(IPrize prize in Prizes)
            {
                _drawer.Remove(prize);
            }
            Prizes.Clear();
        }

        public void AddShoot(IShoot shoot)
        {
            Shoots.Add(shoot);
            _drawer.Add(shoot, _resourceRepository.GetTextureByType(shoot.GetType()));
        }

        public void RemoveShoot(IShoot shoot)
        {
            if (Shoots.Contains(shoot))
            {
                Shoots.Remove(shoot);
                _drawer.Remove(shoot);
            }
        }

        public void RemoveShoots()
        {
            foreach(IShoot shoot in Shoots)
            {
                _drawer.Remove(shoot);
            }
            Shoots.Clear();
        }

        void AddBlock(IBlock block)
        {
            block.AddObserver(this);

            var blockTexture = _resourceRepository.GetTextureByType(block.GetType());
            block.Size = new Size(blockTexture.Width, blockTexture.Height);
            _drawer.Add(block, blockTexture);
        }

        public void AddComponentByAssetName(IGameComponent component, string assetName)
        {
            var texture = _resourceRepository.GetTextureByAssetName(assetName);
            _drawer.Add(component, texture);
        }

        public void Remove(IGameComponent component)
        {
            _drawer.Remove(component);
        }

        public void Draw()
        {
            _drawer.Draw();
        }

        public void Clear()
        {
            _drawer.Clear();
        }

        public void NotifyExplosion(IBlock observable)
        {
            Remove(observable);
        }

        public void PlaySound(string assetName)
        {
            _song = _contentManager.Load<Song>(assetName);
            MediaPlayer.Play(_song);
        }

        public void StopSound()
        {
            MediaPlayer.Stop();
        }
    }
}