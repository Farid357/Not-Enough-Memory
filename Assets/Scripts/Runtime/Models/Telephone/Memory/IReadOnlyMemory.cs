namespace NotEnoughMemory.Model
{
    public interface IReadOnlyMemory
    {
        int Amount { get; }

        bool HasAmountChanged { get; }

        bool IsBroken { get; }

        bool CanClear(int amount);
    }
}