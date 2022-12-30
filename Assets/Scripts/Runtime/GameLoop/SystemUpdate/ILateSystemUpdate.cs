namespace NotEnoughMemory.GameLoop
{
    public interface ILateSystemUpdate : ILateUpdateable
    {
        void Add(params ILateUpdateable[] updateables);
    }
}