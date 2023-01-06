using NotEnoughMemory.Model;

namespace NotEnoughMemory.Storage
{
    public interface ISaveStorages
    {
        ISaveStorage<Money> Money { get; }
        
        void DeleteAllSaves();

    }
}