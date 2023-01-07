using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class UI : MonoBehaviour, IUI
    {
        [SerializeField] private UnityButtons _gameEngineButtons;
        [SerializeField] private Texts _texts;
        [SerializeField] private Windows _windows;
        [SerializeField] private ScrollBars _scrollBars;
        [SerializeField] private Dropdowns _dropdowns;
        [SerializeField] private Screen _screen;
        
        public IGameEngineButtons GameEngineButtons => _gameEngineButtons;

        public ITexts Texts => _texts;
        
        public IWindows Windows => _windows;

        public IScrollBars ScrollBars => _scrollBars;
        
        public IDropdowns Dropdowns => _dropdowns;

        public IScreen Screen => _screen;
        
    }
}