namespace NotEnoughMemory.Factories
{
    public interface IFactory<out T>
    {
        public T Create();
    }
}