using TMPro;
using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class Dropdowns : MonoBehaviour, IDropdowns
    {
        [field: SerializeField] public TMP_Dropdown QualityLevel { get; private set; }
    }
}