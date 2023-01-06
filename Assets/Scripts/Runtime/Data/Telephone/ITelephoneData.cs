using UnityEngine;

namespace NotEnoughMemory.Model
{
    public interface ITelephoneData
    {
        int NeedMemoryFillingAmount { get; }
        
        Sprite Icon { get; }
        
        ParticleSystem ParticlePrefab { get; }
    }
}