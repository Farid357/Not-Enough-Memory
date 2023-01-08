using UnityEngine;

namespace NotEnoughMemory.Game
{
    public sealed class UnscaledGameTime : IGameTime
    {
        public bool IsActive => true;

        public float FixedDelta => Time.fixedUnscaledTime;
        
        public float Delta => Time.unscaledDeltaTime;
        
        public void Stop()
        {
        }

        public void Enable()
        {
            
        }
    }
}