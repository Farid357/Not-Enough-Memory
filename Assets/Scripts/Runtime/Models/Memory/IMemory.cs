namespace NotEnoughMemory.Model
{
    public interface IMemory
    {
        int Amount { get; }
        
        void Fill(int amount);
    }
}