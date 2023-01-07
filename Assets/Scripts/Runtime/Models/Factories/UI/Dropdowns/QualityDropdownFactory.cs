using System;
using System.Collections.Generic;
using System.Linq;
using NotEnoughMemory.Settings;
using NotEnoughMemory.Storage;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Factories
{
    public sealed class QualityDropdownFactory
    {
        private readonly IUI _ui;

        public QualityDropdownFactory(IUI ui)
        {
            _ui = ui ?? throw new ArgumentNullException(nameof(ui));
        }

        public void Create()
        {
            IDropdown<IQualityDropdownOption> qualityDropdown = new QualityDropdown(new QualitySettings());
            List<IQualityDropdownOption> options = CreateQualityOptions();
            IUnityDropdown unityQualityDropdown = new UnityDropdown<IQualityDropdownOption>(_ui.Dropdowns.QualityLevel, options, qualityDropdown
            , new BinaryStorage<int>(new Path(nameof(UnityDropdown<IQualityDropdownOption>))));
            UnityEngine.Debug.Log("Enable dropdown");
            unityQualityDropdown.Enable();
        }
        
        private List<IQualityDropdownOption> CreateQualityOptions()
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