namespace NotEnoughMemory.UI
{
    public interface IUnityButtons
    {
        IUnityButton Telephone { get; }
        
        IUnityButton DeleteAllSaves { get; }
        
        IUnityButton Music { get; }

        IUnityButton Exit { get; }
        
    }
}