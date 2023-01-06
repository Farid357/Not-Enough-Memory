using System;
using NotEnoughMemory.UI.UnityDropDown;
using NotEnoughMemory.View;
using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class QualityDropdown : IDropdown<IQualityDropdownOption>
    {
        private readonly ITextView _textView;

        public QualityDropdown(ITextView textView)
        {
            _textView = textView ?? throw new ArgumentNullException(nameof(textView));
        }

        public void Select(IQualityDropdownOption option)
        {
            QualitySettings.SetQualityLevel((int)option.Level);
            _textView.Visualize(option.Name);
        }
    }
}