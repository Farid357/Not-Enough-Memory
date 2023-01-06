using NotEnoughMemory.Audio;
using NotEnoughMemory.Model;

namespace NotEnoughMemory.View
{
    public interface IViews
    {
        IEffects Effects { get; }

        IAudios Audios { get; }
        
        ITelephoneView Telephone { get; }

        IMemoryView Memory { get; }
    }
}