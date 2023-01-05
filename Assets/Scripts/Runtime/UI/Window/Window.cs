using System;
using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class Window : MonoBehaviour, IWindow
    {
        public bool IsOpened => gameObject.activeInHierarchy;

        public void Open()
        {
            if (IsOpened)
                throw new InvalidOperationException("Window has already been opened!");
            
            gameObject.SetActive(true);
        }

        public void Close()
        {
            if (IsOpened == false)
                throw new InvalidOperationException("Window has already been closed!");
            
            gameObject.SetActive(false);
        }
    }
}