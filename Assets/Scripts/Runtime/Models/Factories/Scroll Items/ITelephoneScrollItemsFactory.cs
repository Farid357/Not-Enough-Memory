using NotEnoughMemory.Model;

namespace NotEnoughMemory.Factories
{
    public interface ITelephoneScrollItemsFactory
    {
        IScrollItem CreateFrom(ITelephoneData telephoneData);
    }
}