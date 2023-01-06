using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class QualitySettings : IQualitySettings
    {
        public void SelectQualityLevel(QualityLevel level)
        {
            UnityEngine.QualitySettings.SetQualityLevel((int)level);
        }
    }
}