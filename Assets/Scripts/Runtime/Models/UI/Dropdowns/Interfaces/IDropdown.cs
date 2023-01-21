namespace NotEnoughMemory.UI
{
    public interface IDropdown<in TOption>
    {
        void Select(TOption option);
    }
}