using NotEnoughMemory.GameLoop;

namespace NotEnoughMemory.Model
{
    public interface ITelephone : IUpdateable
    {
        bool IsBroken { get; }
        
        IMemory Memory { get; }
        
        void Break();
        
        void Fix();
    }
}