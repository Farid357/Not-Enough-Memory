using System;

namespace NotEnoughMemory.UI
{
    public sealed class OpenWindowButton : IButton
    {
        private readonly IWindow _window;

        public OpenWindowButton(IWindow window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public void Press()
        {
            _window.Open();
        }
    }
}