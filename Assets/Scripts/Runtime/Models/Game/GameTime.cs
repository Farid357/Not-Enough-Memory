using UnityEngine;

namespace NotEnoughMemory.Game
{
    public sealed class GameTime : IGameTime
    {
        public bool IsActive => Time.timeScale != 0;
        
        public void Stop()
        {
            Time.timeScale = 0;
        }

        public void Enable()
        {
            Time.timeScale = 1;
        }
    }
}