namespace NotEnoughMemory.UI
{
    public interface IUI
    {
        IGameEngineButtons GameEngineButtons { get; }
        
        ITexts Texts { get; }
        
        IWindows Windows { get; }
        
        IScrollBars ScrollBars { get; }
        
        IDropdowns Dropdowns { get; }
        
        IScreen Screen { get; }
    }
}