using Anarkanoid.Interfaces;

namespace Anarkanoid.Core
{
    public class BasicResourceRepositoryConfiguration : IResourceRepositoryConfiguration
    {
        public string FontAssetName
        {
            get { return "TextFont"; }
        }

        public string SpaceShipTextureAssetName
        {
            get { return "SpaceShip"; }
        }

        public string BasicBallTextureAssetName
        {
            get { return "Ball"; }
        }

        public string FireBallTextureAssetName
        {
            get { return "FireBall"; }
        }

        public string BasicBlockTextureAssetName
        {
            get { return "BlueBlock"; }
        }

        public string ThreeLivesBlockTextureAssetName
        {
            get { return "RedBlock"; }
        }

        public string IrromptableBlockTextureAssetName
        {
            get { return "IrromptableBlock"; }
        }

        public string BasicShootTextureAssetName
        {
            get { return "BasicShoot"; }
        }

        public string BasicShooterPrizeTextureAssetName
        {
            get { return "BasicShooterPrize"; }
        }

        public string ThreeBallsPrizeTextureAssetName
        {
            get { return "ThreeBallsPrize"; }
        }

        public string WiderSpaceShipPrizeTextureAssetName
        {
            get { return "WiderSpaceShipPrize"; }
        }

        public string FireBallPrizeTextureAssetName
        {
            get { return "FireBallPrize"; }
        }

        public string SlowDownBallPrizeTextureAssetName
        {
            get { return "SlowDownBallPrizeTextureAssetName"; }
        }
    }
}