using System;
using System.Collections.Generic;
using System.Linq;

namespace NotEnoughMemory.Storage
{
    public sealed class SaveStorages : ISaveStorages
    {
        private readonly List<ISaveStorage> _all = new();

        public bool HasSaves() => _all.Any(storage => storage.HasSave());

        public void Add(ISaveStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException(nameof(storage));

            _all.Add(storage);
        }

        public void DeleteAllSaves()
        {
            if (HasSaves() == false)
                throw new InvalidOperationException($"{nameof(HasSaves)}== false");

            foreach (var storage in _all)
            {
                if (storage.HasSave())
                    storage.DeleteSave();
            }
        }
    }
}