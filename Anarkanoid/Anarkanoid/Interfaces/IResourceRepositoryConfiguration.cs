namespace Anarkanoid.Interfaces
{
    public interface IResourceRepositoryConfiguration
    {
        string FontAssetName { get; }

        string SpaceShipTextureAssetName { get; }

        string BasicBallTextureAssetName { get; }

        string FireBallTextureAssetName { get; }

        string BasicBlockTextureAssetName { get; }

        string ThreeLivesBlockTextureAssetName { get; }

        string IrromptableBlockTextureAssetName { get; }

        string BasicShootTextureAssetName { get; }

        string BasicShooterPrizeTextureAssetName { get; }

        string ThreeBallsPrizeTextureAssetName { get; }

        string WiderSpaceShipPrizeTextureAssetName { get; }

        string FireBallPrizeTextureAssetName { get; }

        string SlowDownBallPrizeTextureAssetName { get; }
    }
}