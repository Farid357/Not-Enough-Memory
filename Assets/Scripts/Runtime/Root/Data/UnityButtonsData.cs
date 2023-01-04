using NotEnoughMemory.UI;
using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class UnityButtonsData : MonoBehaviour, IUnityButtonsData
    {
        [SerializeField] private UnityButton _telephone;

        public IUnityButton Telephone => _telephone;
    }
}