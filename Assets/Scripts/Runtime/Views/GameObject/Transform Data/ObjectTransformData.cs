using System;
using UnityEngine;

namespace NotEnoughMemory.Model
{
    public sealed class ObjectTransformData : ITransformData
    {
        private readonly Transform _transform;

        public ObjectTransformData(Transform transform)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public Vector3 Position => _transform.position;

        public Quaternion Rotation => _transform.rotation;
    }
}

