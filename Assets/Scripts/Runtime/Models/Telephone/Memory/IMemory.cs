using NotEnoughMemory.Game.Loop;

namespace NotEnoughMemory.Model
{
    public interface IMemory : IReadOnlyMemory, ILateUpdateble
    {
        void Clear();

        void Clear(int amount);

        void Break();
        
        void Fix();
        
        void Fill(int amount);
        
    }
}