using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace NotEnoughMemory.View
{
    public sealed class Screen : MonoBehaviour, IScreen
    {
        [SerializeField] private Image _screen;
        [SerializeField] private float _fadeInSeconds = 1.5f;
        [SerializeField] private float _fadeOutSeconds = 2f;

        private void Start() => DontDestroyOnLoad(gameObject);

        public async Task FadeIn()
        {
            TweenerCore<Color, Color, ColorOptions> tween = _screen.DOFade(1, _fadeInSeconds).SetAutoKill(false);

            while (tween.changeValue.a < tween.endValue.a)
            {
                await Task.Yield();
            }
        }

        public async Task FadeOut()
        {
            TweenerCore<Color, Color, ColorOptions> tween = _screen.DOFade(0, _fadeOutSeconds);

            while (tween.changeValue.a > tween.endValue.a)
            {
                await Task.Yield();
            }
        }
    }
}
