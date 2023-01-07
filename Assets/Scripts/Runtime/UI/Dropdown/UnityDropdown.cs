using System;
using System.Collections.Generic;
using NotEnoughMemory.Storage;
using TMPro;

namespace NotEnoughMemory.UI
{
    public sealed class UnityDropdown<TOption> : IDisposable, IUnityDropdown where TOption : IDropDownOption
    {
        private readonly TMP_Dropdown _unityDropdown;
        private readonly IDropdown<TOption> _dropdown;
        private readonly IReadOnlyList<TOption> _options;
        private readonly ISaveStorage<int> _dropdownValueStorage;
        private readonly IDropdownOptionsDataFactory _optionsDataFactory;

        public UnityDropdown(TMP_Dropdown unityDropdown, IReadOnlyList<TOption> options, IDropdown<TOption> dropdown, ISaveStorage<int> dropdownValueStorage)
        {
            _unityDropdown = unityDropdown ?? throw new ArgumentNullException(nameof(unityDropdown));
            _dropdownValueStorage = dropdownValueStorage ?? throw new ArgumentNullException(nameof(dropdownValueStorage));
            _dropdown = dropdown ?? throw new ArgumentNullException(nameof(dropdown));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _optionsDataFactory = new DropdownOptionsDataFactory<TOption>(_options);
        }

        public void Enable()
        {
            _unityDropdown.AddOptions(_optionsDataFactory.Create());
            _unityDropdown.onValueChanged.AddListener(Select);
            _unityDropdown.value = _dropdownValueStorage.HasSave() ? _dropdownValueStorage.Load() : 0;
            Select(_unityDropdown.value);
        }

        private void Select(int value)
        {
            _dropdown.Select(_options[value]);
            _dropdownValueStorage.Save(value);
        }

        public void Dispose()
        {
            _unityDropdown.onValueChanged.RemoveListener(Select);
        }
    }
}