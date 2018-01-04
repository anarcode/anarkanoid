namespace Anarkanoid.Interfaces
{
    public interface IBlock : IGameComponent
    {
        bool Breakable { get; }

        void Explode();

        void AddObserver(IBlockObserver observer);
    }
}