using NotEnoughMemory.Model;

namespace NotEnoughMemory.Root
{
    public interface IViewData
    {
        ITelephonePressEffect TelephonePressEffect { get; }
        
        ITelephoneView Telephone { get; }
        
        IMemoryView Memory { get; }
    }
}