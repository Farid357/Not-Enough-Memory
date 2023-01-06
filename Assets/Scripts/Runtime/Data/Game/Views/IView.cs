using NotEnoughMemory.Model;

namespace NotEnoughMemory.View
{
    public interface IView
    {
        ITelephonePressEffect TelephonePressEffect { get; }
        
        ITelephoneView Telephone { get; }
        
        IMemoryView Memory { get; }
    }
}