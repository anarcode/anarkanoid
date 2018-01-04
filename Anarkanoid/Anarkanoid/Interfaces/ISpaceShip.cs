namespace Anarkanoid.Interfaces
{
    public interface ISpaceShip : IMobileGameComponent
    {
        IShooter Shooter { get; set; }
    }
}