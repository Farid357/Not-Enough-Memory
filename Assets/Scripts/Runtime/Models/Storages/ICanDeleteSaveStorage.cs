namespace NotEnoughMemory.Storage
{
    public interface ICanDeleteSaveStorage
    {
        bool HasSave();

        void DeleteSave();

    }
}