using System;
using NotEnoughMemory.Model;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NotEnoughMemory.View
{
    public sealed class Effect : IEffect
    {
        private readonly ParticleSystem _prefab;

        public Effect(ParticleSystem prefab)
        {
            _prefab = prefab ? prefab : throw new ArgumentNullException(nameof(prefab));
        }

        public void Play()
        {
            Object.Instantiate(_prefab).Play();
        }

        public void PlayIn(ITransform transform)
        {
            if (transform == null)
                throw new ArgumentNullException(nameof(transform));

            ParticleSystem effect = Object.Instantiate(_prefab, transform.Position, transform.Rotation);
            effect.Play();
        }
    }
}