namespace NotEnoughMemory.GameLoop
{
    public interface ISystemUpdate : IUpdateable
    {
        void Add(params IUpdateable[] updateables);
        
        void Remove(IUpdateable updateable);
    }
}