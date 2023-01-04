namespace NotEnoughMemory.Storage
{
    public interface IStorage<TStoreValue>
    {
        bool HasSave();
        
        TStoreValue Load();

        void Save(TStoreValue saveObject);

        void DeleteSave();
    }
}