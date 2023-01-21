using NotEnoughMemory.UI;

namespace NotEnoughMemory.Model
{
    public interface IScrollItem : IScrollItemView
    {
        bool IsActive { get; }

        void Destroy();
    }
}