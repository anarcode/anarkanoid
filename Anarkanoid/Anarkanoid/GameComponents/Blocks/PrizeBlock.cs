using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.GameComponents.Blocks
{
    public class PrizeBlock : Block
    {
        ComponentManager _componentManager;

        protected IPrize Prize { get; set; }

        public PrizeBlock(IGameConfiguration configuration, Size size, ComponentManager componentManager, IPrize prize) : base(configuration, size)
        {
            _componentManager = componentManager;
            Prize = prize;
        }

        public override void Explode()
        {
            _componentManager.AddPrize(Prize);
            base.Explode();
        }
    }
}