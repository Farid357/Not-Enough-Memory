using UnityEngine;

namespace NotEnoughMemory.Model
{
    public sealed class Transform : ITransform
    {
        public Transform(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public Vector3 Position { get; }
        
        public Quaternion Rotation { get; }
    }
}