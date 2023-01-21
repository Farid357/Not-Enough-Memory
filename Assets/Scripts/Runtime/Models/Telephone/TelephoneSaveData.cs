using System;
using NotEnoughMemory.Model.Tools;

namespace NotEnoughMemory.Model
{
    [Serializable]
    public readonly struct TelephoneSaveData
    {
        public TelephoneSaveData(string name, string iconName, int needMemoryFilling)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            IconName = iconName ?? throw new ArgumentNullException(nameof(iconName));
            NeedMemoryFilling = needMemoryFilling.ThrowIfLessThanOrEqualsToZeroException();
        }

        public string Name { get; }
        
        public string IconName { get; }
        
        public int NeedMemoryFilling { get; }
    }
}