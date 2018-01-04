using Anarkanoid.GameComponents;
using Anarkanoid.GameComponents.Balls;
using Anarkanoid.GameComponents.Blocks;
using Anarkanoid.GameComponents.Shoots;
using Anarkanoid.Interfaces;
using Anarkanoid.Prizes;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Anarkanoid.Core
{
    public class ResourceRepository
    {
        IResourceRepositoryConfiguration _configuration;
        ContentManager _contentManager;
        SpriteFont _font;
        Dictionary<string, Texture2D> _texturesByName;
        readonly Dictionary<Type, string> _texturesByType;

        public ResourceRepository(IResourceRepositoryConfiguration configuration, ContentManager contentManager)
        {
            _configuration = configuration;
            _contentManager = contentManager;
            _texturesByName = new Dictionary<string, Texture2D>();

            _texturesByType = new Dictionary<Type, string>
            {
                { typeof(SpaceShip), _configuration.SpaceShipTextureAssetName },
                { typeof(BasicBall), _configuration.BasicBallTextureAssetName },
                { typeof(FireBall), _configuration.FireBallTextureAssetName },
                { typeof(BasicBlock), _configuration.BasicBlockTextureAssetName },
                { typeof(RandomPrizeBlock), _configuration.BasicBlockTextureAssetName },
                { typeof(ThreeLivesBlock), _configuration.ThreeLivesBlockTextureAssetName },
                { typeof(IrromptableBlock), _configuration.IrromptableBlockTextureAssetName },
                { typeof(BasicShoot), _configuration.BasicShootTextureAssetName },
                { typeof(PrizeBlock), _configuration.BasicBlockTextureAssetName },
                { typeof(BasicShooterPrize), _configuration.BasicShooterPrizeTextureAssetName },
                { typeof(ThreeBallsPrize), _configuration.ThreeBallsPrizeTextureAssetName },
                { typeof(WiderSpaceShipPrize), _configuration.WiderSpaceShipPrizeTextureAssetName },
                { typeof(FireBallPrize), _configuration.FireBallPrizeTextureAssetName },
                { typeof(SlowDownBallPrize), _configuration.SlowDownBallPrizeTextureAssetName }
            };
        }

        public SpriteFont GetFont()
        {
            if(_font == null)
            {
                _font = _contentManager.Load<SpriteFont>(_configuration.FontAssetName);
            }
            return _font;
        }

        public Texture2D GetTextureByType(Type type)
        {
            if (_texturesByType.ContainsKey(type))
            {
                var assetName = _texturesByType[type];
                if (!_texturesByName.ContainsKey(assetName))
                {
                    _texturesByName.Add(assetName, _contentManager.Load<Texture2D>(assetName));
                }

                return _texturesByName[assetName];
            }
            else
            {
                return null;
            }
        }

        public Texture2D GetTextureByAssetName(string assetName)
        {
            if (!_texturesByName.ContainsKey(assetName))
            {
                _texturesByName.Add(assetName, _contentManager.Load<Texture2D>(assetName));
            }
            return _texturesByName[assetName];
        }
    }
}