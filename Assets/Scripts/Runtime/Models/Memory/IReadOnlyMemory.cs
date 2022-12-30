namespace NotEnoughMemory.Model
{
    public interface IReadOnlyMemory
    {
        int Amount { get; }

        bool HasAmountChanged { get; }
    }
}