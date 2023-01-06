using System;
using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class QualityDropdownOption : IQualityDropdownOption
    {
        public string Name { get; }

        public QualityDropdownOption(string name, QualityLevel level)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Level = level;
        }

        public QualityLevel Level { get; }
    }
}