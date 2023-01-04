using System;
using UnityEngine;
using System.IO;
using NotEnoughtMemory.Model.Tools;

namespace NotEnoughMemory.Storage
{
    public sealed class JsonStorage<TStoreValue> : IStorage<TStoreValue>
    {
        private readonly string _pathName;

        public JsonStorage(IPath path)
        {
            if (path is null)
                throw new ArgumentNullException(nameof(path));

            _pathName = path.Name;
        }

        public bool HasSave() => File.Exists(_pathName);

        public TStoreValue Load()
        {
            if (HasSave() == false)
                throw new HasNotSaveException(nameof(TStoreValue));
            
            var saveJson = File.ReadAllText(_pathName);
            return JsonUtility.FromJson<TStoreValue>(saveJson);
        }

        public void Save(TStoreValue saveObject)
        {
            var saveJson = JsonUtility.ToJson(saveObject);
            File.WriteAllText(_pathName, saveJson);
        }


        public void DeleteSave()
        {
            if (HasSave() == false)
                throw new HasNotSaveException(nameof(TStoreValue));
            
            File.Delete(_pathName);
        }
    }
}