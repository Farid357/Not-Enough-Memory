using System;
using UnityEngine;

namespace NotEnoughMemory.Storage
{
    public sealed class Path : IPath
    {
        public Path(string name)
        {
            if (name == null) 
                throw new ArgumentNullException(nameof(name));
            
            Name = Application.persistentDataPath + name;
        }

        public string Name { get; }
    }
}