using System.Collections.Generic;

namespace Anarkanoid.Interfaces
{
    public interface IMatchComponents //struct??
    {
        ISpaceShip SpaceShip { get; }

        List<IBall> Balls { get; }

        IBoard Board { get; }
    }
}