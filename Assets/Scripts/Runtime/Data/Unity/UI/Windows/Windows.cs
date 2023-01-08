using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class Windows : MonoBehaviour, IWindows
    {
        [SerializeField] private Window _exit;
        [SerializeField] private Window _loading;
        [SerializeField] private Window _menu;
        [SerializeField] private Window _game;

        public IWindow Exit => _exit;
        
        public IWindow Loading => _loading;

        public IWindow Menu => _menu;
        
        public IWindow Game => _game;
    }
}