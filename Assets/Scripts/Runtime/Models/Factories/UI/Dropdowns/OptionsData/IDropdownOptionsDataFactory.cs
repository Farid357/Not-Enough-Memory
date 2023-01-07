using System.Collections.Generic;
using TMPro;

namespace NotEnoughMemory.UI
{
    public interface IDropdownOptionsDataFactory
    {
        List<TMP_Dropdown.OptionData> Create();
    }
}