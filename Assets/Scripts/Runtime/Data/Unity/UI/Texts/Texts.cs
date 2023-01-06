using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class Texts : MonoBehaviour, ITexts
    {
        [SerializeField] private Text _money;
        [SerializeField] private Text _loading;

        public IText Money => _money;
        
        public IText Loading => _loading;
        
    }
}