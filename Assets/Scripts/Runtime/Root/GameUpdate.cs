using System;
using NotEnoughMemory.GameLoop;

namespace NotEnoughMemory.Root
{
    public sealed class GameUpdate : IUpdateable, IFixedUpdateable, ILateUpdateable, IGameUpdate
    {
        public GameUpdate(ILateSystemUpdate lateSystemUpdate, IFixedSystemUpdate fixedSystemUpdate, ISystemUpdate systemUpdate)
        {
            LateSystemUpdate = lateSystemUpdate ?? throw new ArgumentNullException(nameof(lateSystemUpdate));
            FixedSystemUpdate = fixedSystemUpdate ?? throw new ArgumentNullException(nameof(fixedSystemUpdate));
            SystemUpdate = systemUpdate ?? throw new ArgumentNullException(nameof(systemUpdate));
        }

        public ILateSystemUpdate LateSystemUpdate { get; }
        
        public IFixedSystemUpdate FixedSystemUpdate { get; }
        
        public ISystemUpdate SystemUpdate { get; }
        
        public void Update(float deltaTime)
        {
            SystemUpdate.Update(deltaTime);
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            FixedSystemUpdate.FixedUpdate(fixedDeltaTime);
        }

        public void LateUpdate(float deltaTime)
        {
            LateSystemUpdate.LateUpdate(deltaTime);
        }
    }
}