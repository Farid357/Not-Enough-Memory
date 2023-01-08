namespace NotEnoughMemory.Game
{
    public interface IGameTime
    {
        bool IsActive { get; }
        
        float FixedDelta { get; }
        
        float Delta { get; }

        void Stop();

        void Enable();
    }
}