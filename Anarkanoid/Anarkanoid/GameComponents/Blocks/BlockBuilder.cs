using Microsoft.Xna.Framework;
using Anarkanoid.Core;
using Anarkanoid.Interfaces;
using Anarkanoid.Prizes;

namespace Anarkanoid.GameComponents.Blocks
{
    public class BlockBuilder
    {
        ComponentManager _componentManager;
        PrizeFactory _prizeFactory;
        IGameConfiguration _configuration;
        Vector2 _scale;
        Color _spriteColor;
        Size _size;
        Vector2 _position;
        BlockType _type;

        public BlockBuilder(ComponentManager componentManager, PrizeFactory prizeFactory)
        {
            _componentManager = componentManager;
            _prizeFactory = prizeFactory;
            _scale = Vector2.Zero;
            _spriteColor = Color.White;
        }

        public BlockBuilder Configuration(IGameConfiguration configuration)
        {
            _configuration = configuration;
            return this;
        }

        public BlockBuilder Scale(Vector2 scale)
        {
            _scale = scale;
            return this;
        }

        public BlockBuilder SpriteColor(Color spriteColor)
        {
            _spriteColor = spriteColor;
            return this;
        }

        public BlockBuilder Size(Size size)
        {
            _size = size;
            return this;
        }

        public BlockBuilder Position(Vector2 position)
        {
            _position = position;
            return this;
        }

        public BlockBuilder Type(BlockType type)
        {
            _type = type;
            return this;
        }

        public IBlock Build()
        {
            IBlock block = null;
            switch (_type)
            {
                case BlockType.Basic:
                    block = new BasicBlock(_configuration, _size);
                    break;
                case BlockType.ThreeLives:
                    block = new ThreeLivesBlock(_configuration, _size);
                    break;
                case BlockType.Irromptable:
                    block = new IrromptableBlock(_configuration, _size);
                    break;
                case BlockType.FireBallPrize:
                    block = new PrizeBlock(_configuration, _size, _componentManager,
                        _prizeFactory.GetFireBallPrize(_position));
                    break;
                case BlockType.ThreeBallsPrize:
                    block = new PrizeBlock(_configuration, _size, _componentManager,
                        _prizeFactory.GetThreeBallsPrize(_position));
                    break;
                case BlockType.BasicShooterPrize:
                    block = new PrizeBlock(_configuration, _size, _componentManager,
                        _prizeFactory.GetBasicShooterPrize(_position));
                    break;
                case BlockType.WiderSpaceShipPrize:
                    block = new PrizeBlock(_configuration, _size, _componentManager,
                        _prizeFactory.GetWiderSpaceShipPrize(_position));
                    break;
                case BlockType.RandomPrize:
                    block = new RandomPrizeBlock(_configuration, _size, _componentManager, _prizeFactory);
                    break;
            }

            if (_position != null)
            {
                block.Position = _position;
            }

            if (_scale != Vector2.Zero)
            {
                block.Scale = _scale;
            }
            
            if (_spriteColor != null)
            {
                block.SpriteColor = _spriteColor;
            }
            return block;
        }
    }
}