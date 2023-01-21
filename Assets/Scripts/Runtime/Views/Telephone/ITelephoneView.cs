using System.Collections.Generic;

namespace NotEnoughMemory.Model
{
    public interface ITelephoneView
    {
        ITelephoneData CurrentData { get; }
        
        IReadOnlyList<ITelephoneData> AllData { get; }
        
        bool ReadyToSwitchAppearance(int memoryFillingAmount);
        
        void SwitchAppearance(int memoryFillingAmount);
        
        void Break();

        void Fix();
    }
}