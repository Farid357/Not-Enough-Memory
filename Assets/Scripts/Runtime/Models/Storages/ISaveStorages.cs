namespace NotEnoughMemory.Storage
{
    public interface ISaveStorages
    {
        bool HasSaves();
        
        void Add(ISaveStorage storage);
        
        void DeleteAllSaves();

    }
}