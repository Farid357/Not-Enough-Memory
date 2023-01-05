using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class UIData : MonoBehaviour, IUIData
    {
        [SerializeField] private UnityButtonsData _unityButtons;
        [SerializeField] private TextsData _texts;
        [SerializeField] private WindowsData _windows;
        
        public IUnityButtonsData UnityButtons => _unityButtons;

        public ITextsData Texts => _texts;
        
        public IWindowsData Windows => _windows;
    }
}