namespace NotEnoughMemory.UI
{
    public interface IButton
    {
        IButton Add(IButtonClickAction clickAction);
        
        void Init();
    }
}