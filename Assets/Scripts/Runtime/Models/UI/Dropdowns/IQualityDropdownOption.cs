using NotEnoughMemory.Settings;

namespace NotEnoughMemory.UI
{
    public interface IQualityDropdownOption : IDropDownOption
    {
        QualityLevel Level { get; }
    }
}