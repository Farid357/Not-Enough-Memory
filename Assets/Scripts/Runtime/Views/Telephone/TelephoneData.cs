using UnityEngine;

namespace NotEnoughMemory.Model
{
    [CreateAssetMenu(menuName = "Create/Telephone Data", fileName = "Telephone Data", order = 0)]
    public sealed class TelephoneData : ScriptableObject
    {
        [field: SerializeField] public int NeedMemoryFillingAmount { get; private set; }
        
        [field: SerializeField] public Sprite Icon { get; private set; }
        
        [field: SerializeField] public ParticleSystem ParticlePrefab { get; private set; }
        
    }
}