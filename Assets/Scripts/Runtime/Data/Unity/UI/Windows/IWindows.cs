namespace NotEnoughMemory.UI
{
    public interface IWindows
    {
        IWindow Exit { get; }
        
        IWindow Loading { get; }
    }
}