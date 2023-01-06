using NotEnoughMemory.UI.UnityDropDown;
using UnityEngine;

namespace NotEnoughMemory.UI
{
    public interface IQualityDropdownOption : IDropDownOption
    {
        QualityLevel Level { get; }
    }
}