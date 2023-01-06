using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class TextsData : MonoBehaviour, ITextsData
    {
        [SerializeField] private Text _money;
        [SerializeField] private Text _loading;

        public IText Money => _money;
        
        public IText Loading => _loading;
    }
}