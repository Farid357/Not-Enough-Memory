using System;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Input
{
    public sealed class OpenWindowInput : IGameLoopObject
    {
        private readonly IKeyDownInput _keyDownInput;
        private readonly IWindow _window;

        public OpenWindowInput(IKeyDownInput keyDownInput, IWindow window)
        {
            _keyDownInput = keyDownInput ?? throw new ArgumentNullException(nameof(keyDownInput));
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public void Update(float deltaTime)
        {
            if (_keyDownInput.WasUsed() && _window.IsOpened == false)
            {
                _window.Open();
            }
        }
    }
}