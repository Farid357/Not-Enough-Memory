using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class UIData : MonoBehaviour, IUIData
    {
        [SerializeField] private UnityButtonsData _unityButtons;
        [SerializeField] private TextsData _texts;
        [SerializeField] private WindowsData _windows;
        [SerializeField] private ScrollBarsData _scrollBars;
        
        public IUnityButtonsData UnityButtons => _unityButtons;

        public ITextsData Texts => _texts;
        
        public IWindowsData Windows => _windows;

        public IScrollBarsData ScrollBars => _scrollBars;
    }
}