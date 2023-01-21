using UnityEngine;

namespace NotEnoughMemory.Model
{
    public sealed class ConstantTransformData : ITransformData
    {
        public ConstantTransformData(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public Vector3 Position { get; }
        
        public Quaternion Rotation { get; }
    }
}