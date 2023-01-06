namespace NotEnoughMemory.UI
{
    public interface IUI
    {
        IUnityButtons UnityButtons { get; }
        
        ITexts Texts { get; }
        
        IWindows Windows { get; }
        
        IScrollBars ScrollBars { get; }
    }
}