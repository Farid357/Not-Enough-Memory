﻿using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class Windows : MonoBehaviour, IWindows
    {
        [SerializeField] private Window _exit;
        [SerializeField] private Window _loading;

        public IWindow Exit => _exit;
        
        public IWindow Loading => _loading;
    }
}