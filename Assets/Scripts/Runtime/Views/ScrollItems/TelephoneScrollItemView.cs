using System;
using NotEnoughMemory.Model;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.View
{
    public sealed class TelephoneScrollItemView : IScrollItemView
    {
        private readonly IGameEngineImage _image;
        private readonly ITextView _nameText;
        private readonly ITextView _needMemoryText;
        private readonly ITelephoneData _telephoneData;

        public TelephoneScrollItemView(IGameEngineImage image, ITextView nameText, ITextView needMemoryText, ITelephoneData telephoneData)
        {
            _image = image ?? throw new ArgumentNullException(nameof(image));
            _nameText = nameText ?? throw new ArgumentNullException(nameof(nameText));
            _needMemoryText = needMemoryText ?? throw new ArgumentNullException(nameof(needMemoryText));
            _telephoneData = telephoneData ?? throw new ArgumentNullException(nameof(telephoneData));
        }

        public void Visualize()
        {
            _image.Visualize(_telephoneData.Icon);
            _nameText.Visualize(_telephoneData.Name);
            _needMemoryText.Visualize(_telephoneData.NeedMemoryFillingAmount);
        }
    }
}