namespace NotEnoughMemory.Model
{
    public interface IMemoryBreaker
    {
        bool TryBreak(IMemory memory);
    }
}