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
        private readonly IGameTime _gameTime;

        public InputsFactory(IWindows windows, IGameUpdate gameUpdate, IGameTime gameTime)
        {
            _windows = windows ?? throw new ArgumentNullException(nameof(windows));
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
        }

        public void Create()
        {
            var openExitWindowInput = new OpenWindowInput(new KeyDownInput(KeyCode.Escape), _windows.Exit, _gameTime);
            _gameUpdate.Add(openExitWindowInput);
        }
    }
}