using System;
using NotEnoughMemory.Game;

namespace NotEnoughMemory.UI
{
    public sealed class CloseWindowButton : IButton
    {
        private readonly IGameTime _gameTime;
        private readonly IWindow _window;

        public CloseWindowButton(IGameTime gameTime, IWindow window)
        {
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public void Press()
        {
            _window.Close();

            if (_gameTime.IsActive == false)
                _gameTime.Enable();
        }
    }
}