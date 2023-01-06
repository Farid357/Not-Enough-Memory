using System;
using UnityEngine;
using UnityEngine.UI;

namespace NotEnoughMemory.SceneLoading
{
    [RequireComponent(typeof(Scrollbar))]
    public sealed class UnityScrollBar : MonoBehaviour, IScrollBar
    {
        private Scrollbar _bar;

        private void Start()
        {
            _bar = GetComponent<Scrollbar>();
        }

        public void Visualize(float fill)
        {
            if (fill < 0)
                throw new ArgumentOutOfRangeException(nameof(fill));

            if (fill > 1)
                throw new ArgumentOutOfRangeException(nameof(fill));
            
            _bar.size = fill;
        }
    }
}