using NotEnoughMemory.SceneLoading;
using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class ScrollBars : MonoBehaviour, IScrollBars
    {
        [SerializeField] private UnityScrollBar _loading;

        public IScrollBar Loading => _loading;
    }
}