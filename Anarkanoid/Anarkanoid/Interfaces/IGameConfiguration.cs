using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Anarkanoid.Core;

namespace Anarkanoid.Interfaces
{
    public interface IGameConfiguration //struct??
    {
        float SpaceShipAccelerationStep { get; }

        float SpaceShipBrakeStep { get; }

        float SpaceShipMaximumSpeed { get; }

        float SpaceShipSeparationFromBottom { get; }

        Vector2 BallInitialSpeed { get; }

        Vector2 BallMinimiumSpeed { get; }

        Vector2 BallMaximumSpeed { get; }

        float BallMaximumBottomPosition { get; }

        Vector2 BallScale { get; }

        double BallInitialHookedMiliseconds { get; }

        Size ScreenSize { get; }

        SpriteFont TextFont { get; }

        int InitialLives { get; }

        List<string> Boards { get; }
    }
}