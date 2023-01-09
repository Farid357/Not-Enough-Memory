using System;
using System.Collections.Generic;
using TMPro;

namespace NotEnoughMemory.UI
{
    public sealed class DropdownOptionsDataFactory<TOption> : IDropdownOptionsDataFactory where TOption : IDropDownOption
    {
        private readonly IReadOnlyList<TOption> _options;

        public DropdownOptionsDataFactory(IReadOnlyList<TOption> options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public List<TMP_Dropdown.OptionData> Create()
        {
            var optionsData = new List<TMP_Dropdown.OptionData>();
            
            foreach (var option in _options)
            {
                optionsData.Add(new TMP_Dropdown.OptionData(option.Name));
            }

            return optionsData;
        }
    }
}