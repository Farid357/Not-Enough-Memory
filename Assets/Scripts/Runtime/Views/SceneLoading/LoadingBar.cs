using UnityEngine;
using UnityEngine.UI;

namespace NotEnoughMemory.SceneLoading
{
    public sealed class LoadingBar : MonoBehaviour
    {
        [SerializeField] private Scrollbar _slider;
        private static Scrollbar _bar;

        private void Start()
        {
            _bar = _slider;
        }

        public static void Visualize(float progress)
        {
            _bar.size = progress / 100f;
        }
    }
}