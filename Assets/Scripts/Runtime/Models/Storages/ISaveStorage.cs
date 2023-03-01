namespace NotEnoughMemory.Storage
{
    public interface ISaveStorage<TStoreValue> : ISaveStorage
    {
        TStoreValue Load();

        void Save(TStoreValue saveObject);
    }

    public interface ISaveStorage
    {
        bool HasSave();

        void DeleteSave();
    }
}