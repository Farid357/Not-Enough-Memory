using System;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Input
{
    public sealed class OpenExitWindowInput : IUpdateable
    {
        private readonly IKeyDownInput _keyDownInput;
        private readonly IWindow _exitWindow;

        public OpenExitWindowInput(IKeyDownInput keyDownInput, IWindow exitWindow)
        {
            _keyDownInput = keyDownInput ?? throw new ArgumentNullException(nameof(keyDownInput));
            _exitWindow = exitWindow ?? throw new ArgumentNullException(nameof(exitWindow));
        }

        public void Update(float deltaTime)
        {
            if (_keyDownInput.WasUsed() && _exitWindow.IsOpened == false)
            {
                _exitWindow.Open();
            }
        }
    }
}