namespace NotEnoughMemory.Storage
{
    public interface ISaveStorages
    {
        void Add(ICanDeleteSaveStorage storage);
        
        void DeleteAllSaves();

    }
}