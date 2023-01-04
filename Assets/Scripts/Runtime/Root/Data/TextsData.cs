using NotEnoughMemory.UI;
using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class TextsData : MonoBehaviour, ITextsData
    {
        [SerializeField] private Text _money;

        public IText Money => _money;
    }
}