namespace NotEnoughMemory.Root
{
    public interface IUIData
    {
        IUnityButtonsData UnityButtons { get; }
        
        ITextsData Texts { get; }
        
        IWindowsData Windows { get; }
    }
}