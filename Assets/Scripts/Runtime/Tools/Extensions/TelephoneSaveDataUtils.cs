using System;
using System.Collections.Generic;
using System.Linq;

namespace NotEnoughMemory.Model.Tools
{
    public static class TelephoneSaveDataUtils
    {
        public static ITelephoneData FindSameFrom(this TelephoneSaveData saveData, IReadOnlyList<ITelephoneData> allData)
        {
            if (allData == null)
                throw new ArgumentNullException(nameof(allData));

            return allData.ToList().Find(data =>
                data.Icon.name == saveData.IconName && data.NeedMemoryFillingAmount == saveData.NeedMemoryFilling &&
                data.Name == saveData.Name);
        }
    }
}