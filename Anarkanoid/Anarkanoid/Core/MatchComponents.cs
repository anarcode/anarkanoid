using Anarkanoid.Interfaces;
using System.Collections.Generic;

namespace Anarkanoid.Core
{
    public class MatchComponents : IMatchComponents
    {
        public List<IBall> Balls { get; private set; }

        public IBoard Board { get; private set; }

        public ISpaceShip SpaceShip { get; private set; }

        public MatchComponents(List<IBall> balls, ISpaceShip spaceShip, IBoard board)
        {
            Balls = balls;
            SpaceShip = spaceShip;
            Board = board;
        }
    }
}