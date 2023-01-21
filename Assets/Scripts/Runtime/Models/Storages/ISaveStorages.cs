namespace NotEnoughMemory.Storage
{
    public interface ISaveStorages
    {
        bool HasSaves();
        
        void Add(ICanDeleteSaveStorage storage);
        
        void DeleteAllSaves();

    }
}