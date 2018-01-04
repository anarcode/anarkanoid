using Microsoft.Xna.Framework.Graphics;
using Anarkanoid.Core;
using System.Collections.Generic;
using Anarkanoid.GameComponents.Balls;

namespace Anarkanoid.Interfaces
{
    public interface IComponentManager : IMatchComponents, IBlockObserver
    {
        SpriteFont Font { get; }

        IGameConfiguration Configuration { get; }

        BallRepository BallRepository { get; }

        List<IShoot> Shoots { get; }

        List<IPrize> Prizes { get; }

        void AddText(IGameComponent component, string text);

        void AddSpaceShip(ISpaceShip spaceShip);

        void AddBall(IBall ball);

        void RemoveBall(IBall ball);

        void RemoveBalls();

        void AddPrize(IPrize prize);

        void RemovePrize(IPrize prize);

        void RemovePrizes();

        void AddShoot(IShoot shoot);

        void RemoveShoot(IShoot shoot);

        void RemoveShoots();

        void AddComponentByAssetName(IGameComponent component, string assetName);

        void LoadBoard(BoardDefinition boardDefinition);

        void Remove(IGameComponent component);

        void Draw();

        void Clear();

        void PlaySound(string assetName);

        void StopSound();
    }
}