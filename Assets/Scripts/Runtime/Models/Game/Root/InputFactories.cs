using System;
using NotEnoughMemory.GameLoop;
using NotEnoughMemory.Input;
using NotEnoughMemory.UI;
using UnityEngine;

namespace NotEnoughMemory.Game
{
    public sealed class InputFactories : IInputFactories
    {
        private readonly IWindowsData _windows;
        private readonly IGameUpdate _gameUpdate;

        public InputFactories(IWindowsData windows, IGameUpdate gameUpdate)
        {
            _windows = windows ?? throw new ArgumentNullException(nameof(windows));
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
        }

        public void CreateOpenExitWindowInput()
        {
            var openExitWindowInput = new OpenExitWindowInput(new KeyDownInput(KeyCode.Escape), _windows.Exit);
            _gameUpdate.Add(openExitWindowInput);
        }
    }
}