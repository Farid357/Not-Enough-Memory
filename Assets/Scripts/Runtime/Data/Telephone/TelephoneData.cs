using NotEnoughMemory.View;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NotEnoughMemory.Model
{
    [CreateAssetMenu(menuName = "Create/Telephone Data", fileName = "Telephone Data", order = 0)]
    public sealed class TelephoneData : ScriptableObject, ITelephoneData
    {
        [SerializeField] private ParticleSystem _particlePrefab;
        
        [field: SerializeField, Min(1)] public int NeedMemoryFillingAmount { get; private set; } = 1;
        
        [field: SerializeField, PreviewField, LabelWidth(100f)] public Sprite Icon { get; private set; }
        
        [field: SerializeField, TextArea] public string Name { get; private set; }

        [field: SerializeField, PreviewField, LabelWidth(100f)] public Sprite BrokenIcon { get; private set; }

        public IEffect Effect { get; private set; }

        private void OnEnable()
        {
            Effect = new Effect(_particlePrefab);
        }
    }
}