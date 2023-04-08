using NotEnoughMemory.Model;

namespace NotEnoughMemory.Factories
{
    public interface ITelephoneScrollItemsFactory
    {
        IScrollItem Create(ITelephoneData telephoneData);
    }
}