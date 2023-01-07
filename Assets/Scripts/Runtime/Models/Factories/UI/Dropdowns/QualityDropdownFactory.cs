using System;
using System.Collections.Generic;
using System.Linq;
using NotEnoughMemory.UI;
using NotEnoughMemory.UI.UnityDropDown;
using UnityEngine;
using QualitySettings = NotEnoughMemory.UI.QualitySettings;

namespace NotEnoughMemory.Factories
{
    public sealed class QualityDropdownFactory
    {
        private readonly IUI _ui;

        public QualityDropdownFactory(IUI ui)
        {
            _ui = ui ?? throw new ArgumentNullException(nameof(ui));
        }

        public IUnityDropdown Create()
        {
            IDropdown<IQualityDropdownOption> qualityDropdown = new QualityDropdown(new QualitySettings());
            IReadOnlyList<IQualityDropdownOption> options = CreateQualityOptions();
            IUnityDropdown unityQualityDropdown = new UnityDropdown<IQualityDropdownOption>(_ui.Dropdowns.QualityLevel, options, qualityDropdown);
            unityQualityDropdown.Enable();
            return unityQualityDropdown;
        }
        
        private IReadOnlyList<IQualityDropdownOption> CreateQualityOptions()
        {
            List<QualityLevel> qualityLevels = Enum.GetValues(typeof(QualityLevel)).Cast<QualityLevel>().ToList();
            var options = new List<IQualityDropdownOption>();
            
            foreach (var qualityLevel in qualityLevels)
            {
                options.Add(new QualityDropdownOption(qualityLevel.ToString(), qualityLevel));
            }

            return options;
        }
    }
}