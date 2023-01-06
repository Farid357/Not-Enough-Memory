using System;
using NotEnoughMemory.Root;

namespace NotEnoughMemory.Game
{
    public sealed class Game : IGame
    {
        private readonly IRoot _root;
        private readonly IGameTime _time;

        public Game(IRoot root, IGameTime time)
        {
            _root = root ?? throw new ArgumentNullException(nameof(root));
            _time = time ?? throw new ArgumentNullException(nameof(time));
        }

        public bool IsPaused => _time.IsActive;
        
        public bool IsNotPaused => !_time.IsActive;

        public void Play()
        {
            _root.Compose();
        }

        public void Pause()
        {
            if (IsPaused)
                throw new InvalidOperationException("Game is already paused!");

            _time.Stop();
        }

        public void Continue()
        {
            if (IsPaused == false)
                throw new InvalidOperationException("Game is not paused!");

            _time.Enable();
        }
    }
}