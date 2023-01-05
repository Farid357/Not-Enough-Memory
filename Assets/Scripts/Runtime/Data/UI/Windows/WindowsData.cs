using NotEnoughMemory.UI;
using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class WindowsData : MonoBehaviour, IWindowsData
    {
        [SerializeField] private Window _exit;

        public IWindow Exit => _exit;
    }
}