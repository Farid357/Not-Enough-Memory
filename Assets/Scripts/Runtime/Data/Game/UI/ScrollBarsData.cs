using NotEnoughMemory.SceneLoading;
using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class ScrollBarsData : MonoBehaviour, IScrollBarsData
    {
        [SerializeField] private UnityScrollBar _loading;

        public IScrollBar Loading => _loading;
    }
}