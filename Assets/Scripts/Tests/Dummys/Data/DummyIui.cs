using NotEnoughMemory.UI;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyIui : IUI
    {
        public IUnityButtons UnityButtons { get; }
        
        public ITexts Texts => new DummyTexts();
        
        public IWindows Windows { get; }
        
        public IScrollBars ScrollBars { get; }
    }
}