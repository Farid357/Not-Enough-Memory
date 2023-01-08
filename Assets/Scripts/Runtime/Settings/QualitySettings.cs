using System;
using NotEnoughMemory.Settings;

namespace NotEnoughMemory.UI
{
    public sealed class QualitySettings : IQualitySettings
    {
        public void SelectQualityLevel(QualityLevel level)
        {
            int qualityLevelIndex = QualityLevelIndex(level);
            UnityEngine.QualitySettings.SetQualityLevel(qualityLevelIndex);
        }

        private int QualityLevelIndex(QualityLevel qualityLevel)
        {
            return qualityLevel switch
            {
                QualityLevel.Fastest => 0,
                QualityLevel.Fast => 1,
                QualityLevel.Simple => 2,
                QualityLevel.Good => 3,
                QualityLevel.Beautiful => 4,
                QualityLevel.Fantastic => 5,
                _ => throw new ArgumentOutOfRangeException(nameof(qualityLevel), qualityLevel, null)
            };
        }
    }
}