namespace NotEnoughMemory.UI
{
    public interface IWindowsData
    {
        IWindow Exit { get; }
        
        IWindow Loading { get; }
    }
}