using System;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;
using UnityEngine;
using UnityEngine.UI;
using Text = NotEnoughMemory.UI.Text;

namespace NotEnoughMemory.Model
{
    public sealed class TelephoneScrollItem : MonoBehaviour, IScrollItem
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _nameText;
        [SerializeField] private Text _needMemoryText;
        private ITelephoneData _telephoneData;

        public bool IsActive => gameObject.activeInHierarchy;

        public void Init(ITelephoneData telephoneData)
        {
            _telephoneData = telephoneData ?? throw new ArgumentNullException(nameof(telephoneData));
        }
        
        public void Visualize()
        {
            IGameEngineImage image = new UnityImage(_image);
            ITextView nameText = new TextView(_nameText);
            ITextView needMemoryText = new TextView(_needMemoryText);
            IScrollItemView view = new TelephoneScrollItemView(image, nameText, needMemoryText, _telephoneData);
            view.Visualize();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}