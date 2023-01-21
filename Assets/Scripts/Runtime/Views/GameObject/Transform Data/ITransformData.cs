using UnityEngine;

namespace NotEnoughMemory.Model
{
    public interface ITransformData
    {
        Vector3 Position { get; }

        Quaternion Rotation { get; }
    }
}