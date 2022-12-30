namespace NotEnoughMemory.Model
{
    public interface IRandom
    {
        bool TryGetLuckyNumberFrom(IChance chance);
    }
}