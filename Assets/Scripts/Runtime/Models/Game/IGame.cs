namespace NotEnoughMemory.Game
{
    public interface IGame
    {
        bool IsNotPaused { get; }

        bool IsPaused { get; }
        
        void Play();

        void Pause();

        void Continue();
    }
}