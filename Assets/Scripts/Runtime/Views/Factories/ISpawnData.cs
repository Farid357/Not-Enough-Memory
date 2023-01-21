using NotEnoughMemory.Model;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NotEnoughMemory.Factories
{
    public interface ISpawnData<out TPrefab> where TPrefab : Object
    {
        ITransformData SpawnTransform { get; }
        
        TPrefab Prefab { get; }

        bool HasParent();
        
        Transform Parent();
    }
}