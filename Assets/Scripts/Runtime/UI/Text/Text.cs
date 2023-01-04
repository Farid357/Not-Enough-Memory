using TMPro;
using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class Text : MonoBehaviour, IText
    {
        [SerializeField] private TMP_Text _text;
        
        public void Visualize(string value)
        {
            _text.text = value;
        }
    }
}