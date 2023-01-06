using System;
using System.Collections.Generic;
using System.Linq;
using NotEnoughMemory.Game;
using NotEnoughMemory.UI;
using NotEnoughMemory.UI.UnityDropDown;
using UnityEngine;
using QualitySettings = NotEnoughMemory.UI.QualitySettings;

namespace NotEnoughMemory.Factories
{
    //Need Refactoring
    public sealed class GameUIFactory : IGameUIFactory
    {
        private readonly IUnity _unity;
        private readonly IGameTime _gameTime;

        public GameUIFactory(IUnity unity, IGameTime gameTime)
        {
            _unity = unity ?? throw new ArgumentNullException(nameof(unity));
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
        }

        public void Create()
        {
            IUI ui = _unity.UI;
            ui.UnityButtons.Exit.Init(new SceneLoadButton(_unity.SceneLoader, _unity.Scenes.Menu));
            ui.UnityButtons.CloseExitWindow.Init(new CloseWindowButton(_gameTime, ui.Windows.Exit));
            IDropdown<IQualityDropdownOption> qualityDropdown = new QualityDropdown(new QualitySettings());
            IUnityDropdown unityQualityDropdown = new UnityDropdown<IQualityDropdownOption>(ui.Dropdowns.QualityLevel, CreateQualityOptions(), qualityDropdown);
            unityQualityDropdown.Enable();
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