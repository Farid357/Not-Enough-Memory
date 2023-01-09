using System;
using System.Collections.Generic;

namespace NotEnoughMemory.Storage
{
    public sealed class SaveStorages : ISaveStorages
    {
        private readonly List<ICanDeleteSaveStorage> _all = new();
        
        public void Add(ICanDeleteSaveStorage storage)
        {
            if (storage == null) 
                throw new ArgumentNullException(nameof(storage));
            
            _all.Add(storage);
        }
        
        public void DeleteAllSaves()
        {
            foreach (var storage in _all)
            {
                if (storage.HasSave())
                    storage.DeleteSave();
            }
        }

    }
}