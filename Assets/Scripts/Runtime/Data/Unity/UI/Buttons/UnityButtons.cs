using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class UnityButtons : MonoBehaviour, IUnityButtons
    {
        [SerializeField] private UnityButton _telephone;
        [SerializeField] private UnityButton _deleteAllSaves;
        [SerializeField] private UnityButton _music;
        [SerializeField] private UnityButton _exit;
        [SerializeField] private UnityButton _closeExitWindow;

        public IUnityButton Telephone => _telephone;
        
        public IUnityButton DeleteAllSaves => _deleteAllSaves;
        
        public IUnityButton Music => _music;
        
        public IUnityButton Exit => _exit;
        
        public IUnityButton CloseExitWindow => _closeExitWindow;
    }
}