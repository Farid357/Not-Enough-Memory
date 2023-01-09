using NotEnoughMemory.Storage;

namespace NotEnoughMemory.Tests
{
    public sealed class DummySaveStorages : ISaveStorages
    {
        public void Add(ICanDeleteSaveStorage storage)
        {
           
        }

        public void DeleteAllSaves()
        {
            
        }
    }
}