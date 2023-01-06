using System;
using NotEnoughMemory.UI.UnityDropDown;

namespace NotEnoughMemory.UI
{
    public sealed class QualityDropdown : IDropdown<IQualityDropdownOption>
    {
        private readonly IQualitySettings _qualitySettings;

        public QualityDropdown(IQualitySettings qualitySettings)
        {
            _qualitySettings = qualitySettings ?? throw new ArgumentNullException(nameof(qualitySettings));
        }

        public void Select(IQualityDropdownOption qualityOption)
        {
            _qualitySettings.SelectQualityLevel(qualityOption.Level);
        }
    }
}