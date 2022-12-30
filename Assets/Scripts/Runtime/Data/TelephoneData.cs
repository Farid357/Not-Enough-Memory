using Sirenix.OdinInspector;
using UnityEngine;

namespace NotEnoughMemory.Model
{
    [CreateAssetMenu(menuName = "Create/Telephone Data", fileName = "Telephone Data", order = 0)]
    public sealed class TelephoneData : ScriptableObject, ITelephoneData
    {
        [field: SerializeField, Min(1)] public int NeedMemoryFillingAmount { get; private set; } = 1;
        
        [field: SerializeField, PreviewField, LabelWidth(100f)] public Sprite Icon { get; private set; }
        
        [field: SerializeField, PreviewField, LabelWidth(100f)] public Sprite BrokenIcon { get; private set; }

        [field: SerializeField, GUIColor(1, 0, 1)] public ParticleSystem ParticlePrefab { get; private set; }
    }
}