using NotEnoughMemory.UI;
using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class ButtonsData : MonoBehaviour, IButtonsData
    {
        [SerializeField] private Button _telephone;

        public IButton Telephone => _telephone;
    }
}