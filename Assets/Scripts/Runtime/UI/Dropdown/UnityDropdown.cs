using System;
using System.Collections.Generic;
using System.Linq;
using NotEnoughMemory.Storage;
using TMPro;

namespace NotEnoughMemory.UI.UnityDropDown
{
    public sealed class UnityDropdown<TOption> : IDisposable, IUnityDropdown where TOption : IDropDownOption
    {
        private readonly TMP_Dropdown _unityDropdown;
        private readonly IDropdown<TOption> _dropdown;
        private readonly IReadOnlyList<TOption> _options;
        private readonly ISaveStorage<int> _dropdownValueStorage;

        public UnityDropdown(TMP_Dropdown unityDropdown, IReadOnlyList<TOption> options, IDropdown<TOption> dropdown)
        {
            _unityDropdown = unityDropdown ?? throw new ArgumentNullException(nameof(unityDropdown));
            _dropdownValueStorage = new BinaryStorage<int>(new Path(nameof(TOption)));
            _dropdown = dropdown ?? throw new ArgumentNullException(nameof(dropdown));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Enable()
        {
            _unityDropdown.AddOptions(CreateOptions().ToList());
            _unityDropdown.onValueChanged.AddListener(Select);
            _unityDropdown.value = _dropdownValueStorage.HasSave() ? _dropdownValueStorage.Load() : 0;
            Select(_unityDropdown.value);
        }

        private void Select(int value)
        {
            _dropdown.Select(_options[value]);
            _dropdownValueStorage.Save(value);
        }

        private IEnumerable<TMP_Dropdown.OptionData> CreateOptions()
        {
            foreach (var option in _options)
            {
                UnityEngine.Debug.Log("Create option");
                yield return new TMP_Dropdown.OptionData(option.Name);
            }
        }

        public void Dispose()
        {
            _unityDropdown.onValueChanged.RemoveListener(Select);
        }
    }
}