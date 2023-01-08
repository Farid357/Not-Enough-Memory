namespace NotEnoughMemory.Game
{
    public interface IReadOnlyGameTime
    {
        bool IsActive { get; }
        
        float FixedDelta { get; }
        
        float Delta { get; }
    }
}