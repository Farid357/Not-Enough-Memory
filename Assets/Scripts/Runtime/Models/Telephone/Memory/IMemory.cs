using NotEnoughMemory.GameLoop;

namespace NotEnoughMemory.Model
{
    public interface IMemory : IReadOnlyMemory, ILateUpdateable
    {
        void Clear();

        void Clear(int amount);

        void Break();
        
        void Fix();
        
        void Fill(int amount);
        
    }
}