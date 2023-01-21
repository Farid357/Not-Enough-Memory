using System;
using NotEnoughMemory.Model;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NotEnoughMemory.Factories
{
    [Serializable]
    public sealed class SpawnData<TPrefab> : ISpawnData<TPrefab> where TPrefab : Object
    {
        [SerializeField] private TPrefab _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _parent;

        public ITransformData SpawnTransform => new ConstantTransformData(_spawnPoint.position, Quaternion.identity);
        
        public TPrefab Prefab => _prefab;
        
        public bool HasParent() => _parent != null;

        public Transform Parent()
        {
            if (HasParent())
                return _parent;

            throw new InvalidOperationException("Spawn Data doesn't have parent!");
        }
    }
}