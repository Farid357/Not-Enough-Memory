using NotEnoughMemory.UI;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyUI : IUI
    {
        public IGameEngineButtons GameEngineButtons { get; }
        
        public ITexts Texts => new DummyTexts();

        public IWindows Windows => new DummyWindows();
        
        public IScrollBars ScrollBars { get; }
        
        public IDropdowns Dropdowns { get; }
        
        public IScreen Screen => new DummyScreen();
    }
}