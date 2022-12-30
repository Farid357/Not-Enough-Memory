namespace NotEnoughMemory.Model
{
    public interface ITelephoneView
    {
        ITelephoneData Data { get; }
        
        bool ReadyToSwitchAppearance(int memoryFillingAmount);
        
        void SwitchAppearance(int memoryFillingAmount);
    }
}