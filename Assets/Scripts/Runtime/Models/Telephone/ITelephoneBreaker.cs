namespace NotEnoughMemory.Model
{
    public interface ITelephoneBreaker
    {
        bool TryBreak(ITelephone telephone);
    }
}