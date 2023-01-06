namespace NotEnoughMemory.Game
{
    public interface IGameTime
    {
        bool IsActive { get; }

        void Stop();

        void Enable();
    }
}