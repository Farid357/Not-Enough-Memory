using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class Texts : MonoBehaviour, ITexts
    {
        [SerializeField] private Text _money;
        [SerializeField] private Text _loading;
        [SerializeField] private Text _qualityLevel;

        public IText Money => _money;
        
        public IText Loading => _loading;
        
        public IText QualityLevel => _qualityLevel;
    }
}