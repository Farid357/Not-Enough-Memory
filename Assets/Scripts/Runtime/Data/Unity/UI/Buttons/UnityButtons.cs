using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class UnityButtons : MonoBehaviour, IGameEngineButtons
    {
        [SerializeField] private UnityButton _telephone;
        [SerializeField] private UnityButton _deleteAllSaves;
        [SerializeField] private UnityButton _music;
        [SerializeField] private UnityButton _exitGame;
        [SerializeField] private UnityButton _closeExitWindow;
        [SerializeField] private UnityButton _play;
        [SerializeField] private UnityButton _exitMenu;

        public IGameEngineButton Telephone => _telephone;
        
        public IGameEngineButton DeleteAllSaves => _deleteAllSaves;
        
        public IGameEngineButton Music => _music;
        
        public IGameEngineButton ExitGame => _exitGame;
        
        public IGameEngineButton ExitMenu => _exitMenu; 

        public IGameEngineButton CloseExitWindow => _closeExitWindow;
        
        public IGameEngineButton Play => _play;
    }
}