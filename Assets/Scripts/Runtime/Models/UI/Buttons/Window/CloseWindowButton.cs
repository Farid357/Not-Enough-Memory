using System;
using NotEnoughMemory.Game;

namespace NotEnoughMemory.UI
{
    public sealed class CloseWindowButton : IButton
    {
        private readonly IWindow _window;

        public CloseWindowButton(IWindow window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public void Press()
        {
            _window.Close();
        }
    }
}