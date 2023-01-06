namespace NotEnoughMemory.UI.UnityDropDown
{
    public interface IDropdown<in TOption>
    {
        void Select(TOption option);
    }
}