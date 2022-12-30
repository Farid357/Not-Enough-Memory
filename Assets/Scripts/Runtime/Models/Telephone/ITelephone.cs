namespace NotEnoughMemory.Model
{
    public interface ITelephone
    {
        bool IsBroken { get; }
        
        IMemory Memory { get; }
        
        void Break();
        
        void Fix();
    }
}