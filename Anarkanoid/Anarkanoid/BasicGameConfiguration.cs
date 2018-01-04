using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid
{
    public class BasicGameConfiguration : IGameConfiguration
    {
        readonly Vector2 _ballMinimunSpeed = new Vector2(1, 1);

        readonly Vector2 _ballMaximunSpeed = new Vector2(1, 1);

        readonly Vector2 _ballInitialSpeed = new Vector2(2, -2);

        readonly Size _screenSize = new Size(800, 600);

        public float SpaceShipAccelerationStep
        {
            get { return .6f; }
        }

        public float SpaceShipBrakeStep
        {
            get { return .1f; }
        }

        public float SpaceShipMaximumSpeed
        {
            get { return 15f; }
        }

        public float SpaceShipSeparationFromBottom
        {
            get { return 5f; }
        }

        public Vector2 BallMinimiumSpeed
        {
            get { return _ballMinimunSpeed; }
        }

        public Vector2 BallMaximumSpeed
        {
            get { return _ballMaximunSpeed; }
        }

        public Vector2 BallInitialSpeed
        {
            get { return _ballInitialSpeed; }
        }

        public float BallMaximumBottomPosition { get; set; }

        public Vector2 BallScale
        {
            get { return new Vector2(.5f, .5f); }
        }

        public double BallInitialHookedMiliseconds
        {
            get { return 3000; }
        }

        public int InitialLives
        {
            get { return 3; }
        }

        public List<string> Boards { get; private set; }

        public Size ScreenSize { get { return _screenSize; } }

        public SpriteFont TextFont { get; private set; }

        public BasicGameConfiguration(float spaceShipHeigth, SpriteFont textFont)
        {
            BallMaximumBottomPosition = ScreenSize.Height - spaceShipHeigth - SpaceShipSeparationFromBottom;
            TextFont = textFont;
            Boards = new List<string>
            {
                "FirstStage"
            };
        }
    }
}