using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class UI : MonoBehaviour, IUI
    {
        [SerializeField] private UnityButtons _unityButtons;
        [SerializeField] private Texts _texts;
        [SerializeField] private Windows _windows;
        [SerializeField] private ScrollBars _scrollBars;
        [SerializeField] private Dropdowns _dropdowns;

        public IUnityButtons UnityButtons => _unityButtons;

        public ITexts Texts => _texts;
        
        public IWindows Windows => _windows;

        public IScrollBars ScrollBars => _scrollBars;
        
        public IDropdowns Dropdowns => _dropdowns;
    }
}