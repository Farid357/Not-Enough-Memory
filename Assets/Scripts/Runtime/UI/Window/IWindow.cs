namespace NotEnoughMemory.UI
{
    public interface IWindow
    {
        bool IsOpened { get; }
        
        void Open();

        void Close();
    }
}