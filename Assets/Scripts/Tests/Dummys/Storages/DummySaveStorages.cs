using System;
using NotEnoughMemory.Storage;

namespace NotEnoughMemory.Tests
{
    public sealed class DummySaveStorages : ISaveStorages
    {
        public bool HasSaves() => false;

        public void Add(ICanDeleteSaveStorage storage)
        {
           
        }

        public void DeleteAllSaves()
        {
            throw new InvalidOperationException("Has not saves!");
        }
    }
}