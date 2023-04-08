using UnityEngine;

namespace NotEnoughMemory.Model
{
    public interface ITransform
    {
        Vector3 Position { get;}
        
        Quaternion Rotation { get; }
    }
}