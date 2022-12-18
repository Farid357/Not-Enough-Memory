namespace NotEnoughMemory.Model
{
    public interface ITelephoneView
    {
        TelephoneData Data { get; }
        
        bool ReadyToSwitchAppearance(int memoryFillingAmount);
        
        void SwitchAppearance(int memoryFillingAmount);
    }
}