using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class UnityButtons : MonoBehaviour, IGameEngineButtons
    {
        [SerializeField] private UnityButton _telephone;
        [SerializeField] private UnityButton _deleteAllSaves;
        [SerializeField] private UnityButton _music;
        [SerializeField] private UnityButton _exit;
        [SerializeField] private UnityButton _closeExitWindow;
        [SerializeField] private UnityButton _play;
        
        public IGameEngineButton Telephone => _telephone;
        
        public IGameEngineButton DeleteAllSaves => _deleteAllSaves;
        
        public IGameEngineButton Music => _music;
        
        public IGameEngineButton Exit => _exit;
        
        public IGameEngineButton CloseExitWindow => _closeExitWindow;
        
        public IGameEngineButton Play => _play;
    }
}