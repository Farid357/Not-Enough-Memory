using System;
using NotEnoughMemory.Game;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Input
{
    public sealed class OpenWindowInput : IUpdateable
    {
        private readonly IKeyDownInput _keyDownInput;
        private readonly IWindow _window;
        private readonly IGameTime _gameTime;

        public OpenWindowInput(IKeyDownInput keyDownInput, IWindow window, IGameTime gameTime)
        {
            _keyDownInput = keyDownInput ?? throw new ArgumentNullException(nameof(keyDownInput));
            _window = window ?? throw new ArgumentNullException(nameof(window));
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
        }

        public void Update(float deltaTime)
        {
            if (_keyDownInput.WasUsed() && _window.IsOpened == false)
            {
                _window.Open();
                _gameTime.Stop();
            }
        }
    }
}