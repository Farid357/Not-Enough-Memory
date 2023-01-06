namespace NotEnoughMemory.Game
{
    public interface IGame
    {
        bool IsNotPaused { get; }

        bool IsPaused { get; }

        void Pause();

        void Continue();
    }
}