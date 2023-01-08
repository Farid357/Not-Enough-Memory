namespace NotEnoughMemory.Game
{
    public interface IGameTime : IReadOnlyGameTime
    {
        void Stop();

        void Enable();
    }
}