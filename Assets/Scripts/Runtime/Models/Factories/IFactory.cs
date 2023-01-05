namespace NotEnoughMemory.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}