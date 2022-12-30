namespace NotEnoughMemory.Model
{
    public interface IMemory : IReadOnlyMemory
    {
        void Clear();

        void Clear(int amount);

        void Break();
        
        void Fix();
        
        void Fill(int amount);
        
    }
}