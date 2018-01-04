namespace Anarkanoid.Interfaces
{
    public interface IBall : IMobileGameComponent
    {
        bool Rebounds { get; }

        bool IsGoingUp { get; }

        bool IsGoingLeft { get; }

        bool Hooked { get; }

        void Unhook();

        IBall Clone();
    }
}