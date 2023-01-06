using NotEnoughMemory.Model;

namespace NotEnoughMemory.View
{
    public interface IViewData
    {
        ITelephonePressEffect TelephonePressEffect { get; }
        
        ITelephoneView Telephone { get; }
        
        IMemoryView Memory { get; }
    }
}