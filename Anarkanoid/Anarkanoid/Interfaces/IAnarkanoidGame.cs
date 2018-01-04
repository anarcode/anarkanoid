namespace Anarkanoid.Interfaces
{
    public interface IAnarkanoidGame
    {
        IComponentManager ComponentManager { get; }

        void ExitGame();

        void ToggleFullScreen();

        int CurrentLives { get; set; }

        int CurrentStage { get; set; }
    }
}