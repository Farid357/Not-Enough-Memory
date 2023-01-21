using NotEnoughMemory.Factories;

namespace NotEnoughMemory.View
{
    public interface IViewsFactories
    {
        ITelephoneScrollItemsFactory TelephoneScrollItemsFactory { get; }
    }
}