namespace NotEnoughMemory.Model
{
    public interface IMemory : IReadOnlyMemory
    {
        void Clear();
        
        void Fill(int amount);
    }
}