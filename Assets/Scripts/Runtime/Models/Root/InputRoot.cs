using System;
using NotEnoughMemory.GameLoop;
using NotEnoughMemory.Input;
using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class InputRoot : IRoot
    {
        private readonly IWindowsData _windows;
        private readonly IGameUpdate _gameUpdate;

        public InputRoot(IWindowsData windows, IGameUpdate gameUpdate)
        {
            _windows = windows ?? throw new ArgumentNullException(nameof(windows));
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
        }

        public void Compose()
        {
            var openExitWindowInput = new OpenExitWindowInput(new KeyDownInput(KeyCode.Escape), _windows.Exit);
            _gameUpdate.Add(openExitWindowInput);
        }
    }
}