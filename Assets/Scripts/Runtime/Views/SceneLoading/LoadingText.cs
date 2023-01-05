using TMPro;
using UnityEngine;

namespace NotEnoughMemory.SceneLoading
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class LoadingText : MonoBehaviour
    {
        private static TextMeshProUGUI _text;

        private void Start() => _text = GetComponent<TextMeshProUGUI>();

        public static void Visualize(float progress)
        {
            var valueText = progress.ToString();

            if (valueText.Length > 2)
                valueText = $"{valueText[0]}{valueText[1]}";
            
            _text.text = $"{valueText} %";
        }
    }
}