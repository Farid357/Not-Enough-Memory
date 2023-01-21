namespace NotEnoughMemory.Storage
{
    public interface ISaveStorage<TStoreValue> : ICanDeleteSaveStorage
    {
        TStoreValue Load();

        void Save(TStoreValue saveObject);
    }
}