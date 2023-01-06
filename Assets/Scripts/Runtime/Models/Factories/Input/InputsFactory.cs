using System;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.Input;
using NotEnoughMemory.UI;
using UnityEngine;

namespace NotEnoughMemory.Game
{
    public sealed class InputsFactory : IInputsFactory
    {
        private readonly IWindows _windows;
        private readonly IGameUpdate _gameUpdate;

        public InputsFactory(IWindows windows, IGameUpdate gameUpdate)
        {
            _windows = windows ?? throw new ArgumentNullException(nameof(windows));
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
        }

        public void Create()
        {
            var openExitWindowInput = new OpenExitWindowInput(new KeyDownInput(KeyCode.Escape), _windows.Exit);
            _gameUpdate.Add(openExitWindowInput);
        }
    }
}