namespace NotEnoughMemory.UI
{
    public interface IUIData
    {
        IUnityButtonsData UnityButtons { get; }
        
        ITextsData Texts { get; }
        
        IWindowsData Windows { get; }
        
        IScrollBarsData ScrollBars { get; }
    }
}