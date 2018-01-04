using Anarkanoid.Core;
using Anarkanoid.Interfaces;

namespace Anarkanoid.GameComponents.Balls
{
    public class BallRepository
    {
        IGameConfiguration _configuration;
        Size _size;

        public BallRepository(IGameConfiguration configuration, Size size)
        {
            _configuration = configuration;
            _size = size;
        }

        public IBall GetBasicBall()
        {
            return new BasicBall(_configuration, _size);
        }

        public IBall GetFireBall()
        {
            return new FireBall(_configuration, _size);
        }
    }
}