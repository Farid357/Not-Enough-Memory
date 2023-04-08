using NotEnoughMemory.Model;

namespace NotEnoughMemory.View
{
    public interface IEffect
    {
        void Play();
        
        void PlayIn(ITransform transform);
    }
}