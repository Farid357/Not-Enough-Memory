using NotEnoughMemory.UI;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyUIData : IUIData
    {
        public IUnityButtonsData UnityButtons { get; }
        
        public ITextsData Texts => new DummyTextsData();
        
        public IWindowsData Windows { get; }
        
        public IScrollBarsData ScrollBars { get; }
    }
}