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
        private readonly IGameLoopObjects _gameLoopObjects;

        public InputsFactory(IWindows windows, IGameLoopObjects gameLoopObjects)
        {
            _windows = windows ?? throw new ArgumentNullException(nameof(windows));
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
        }

        public void Create()
        {
            var openExitWindowInput = new OpenWindowInput(new KeyDownInput(KeyCode.Escape), _windows.Exit);
            _gameLoopObjects.Add(openExitWindowInput);
        }
    }
}