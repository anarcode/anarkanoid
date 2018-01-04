using Anarkanoid.Core;
using Anarkanoid.Interfaces;
using Anarkanoid.Prizes;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Anarkanoid.GameComponents.Blocks
{
    public class RandomPrizeBlock : PrizeBlock
    {
        delegate IPrize ReturnPrize(PrizeFactory prizeFactory);

        public override Vector2 Position
        {
            get { return base.Position; }
            set
            {
                base.Position = value;
                if(Prize != null)
                {
                    Prize.Position = value;
                }
            }
        }

        public RandomPrizeBlock(IGameConfiguration configuration, Size size, ComponentManager componentManager, PrizeFactory prizeFactory) : base(configuration, size, componentManager, null)
        {
            Dictionary<Type, ReturnPrize> returningPrizes = new Dictionary<Type, ReturnPrize>
            {
                { typeof(BasicShooterPrize), NewBasicShooterPrize },
                { typeof(FireBallPrize), NewFireBallPrize },
                { typeof(ThreeBallsPrize), NewThreeBallsPrize },
                { typeof(WiderSpaceShipPrize), NewWiderSpaceShipPrize },
                { typeof(SlowDownBallPrize), NewSlowDownBallPrize }
            };

            List<Type> types = new List<Type>(returningPrizes.Keys);

            var rnd = new Random();
            int randomNumber = rnd.Next(returningPrizes.Count);
            
            //Aqui juego con el azarrrrrr
            Prize = returningPrizes[types[randomNumber]](prizeFactory);
        }

        IPrize NewBasicShooterPrize(PrizeFactory prizeFactory)
        {
            return prizeFactory.GetWiderSpaceShipPrize(Position);
        }

        IPrize NewFireBallPrize(PrizeFactory prizeFactory)
        {
            return prizeFactory.GetFireBallPrize(Position);
        }

        IPrize NewThreeBallsPrize(PrizeFactory prizeFactory)
        {
            return prizeFactory.GetThreeBallsPrize(Position);
        }

        IPrize NewWiderSpaceShipPrize(PrizeFactory prizeFactory)
        {
            return prizeFactory.GetWiderSpaceShipPrize(Position);
        }

        IPrize NewSlowDownBallPrize(PrizeFactory prizeFactory)
        {
            return prizeFactory.GetSlowDownBallPrize(Position);
        }
    }
}