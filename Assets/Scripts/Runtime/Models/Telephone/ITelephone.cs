using NotEnoughMemory.Game.Loop;

namespace NotEnoughMemory.Model
{
    public interface ITelephone : IUpdateble
    {
        bool IsBroken { get; }
        
        IMemory Memory { get; }
        
        void Break();
        
        void Fix();
    }
}