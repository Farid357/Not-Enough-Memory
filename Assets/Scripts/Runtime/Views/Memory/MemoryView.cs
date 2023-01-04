using NotEnoughMemory.Model;
using TMPro;
using UnityEngine;

namespace NotEnoughMemory.View
{
    public sealed class MemoryView : MonoBehaviour, IMemoryView
    {
        [SerializeField] private TMP_Text _text;
        
        public void Visualize(int maxAmount, int amount)
        {
            _text.text = $"{Mathf.Lerp(0, 100, (float)amount / maxAmount)}%";
        }
    }
}