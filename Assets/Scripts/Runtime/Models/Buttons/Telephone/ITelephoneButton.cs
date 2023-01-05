using NotEnoughMemory.Model;

namespace NotEnoughMemory.UI
{
    public interface ITelephoneButton : IButton
    {
        ITelephone Telephone { get; }
    }
}