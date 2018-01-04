namespace Anarkanoid.Interfaces
{
    public interface IBlockObserver
    {
        void NotifyExplosion(IBlock observable);
    }
}