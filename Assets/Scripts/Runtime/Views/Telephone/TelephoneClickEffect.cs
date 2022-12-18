using System;
using UnityEngine;

namespace NotEnoughMemory.Model
{
    public sealed class TelephoneClickEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particlePrefab;
        [SerializeField] private Transform _spawnPosition;
        
        public void SwitchPrefab(ParticleSystem particlePrefab)
        {
            _particlePrefab = particlePrefab ?? throw new ArgumentNullException(nameof(particlePrefab));
        }

        public void Play()
        {
            var particle = Instantiate(_particlePrefab, _spawnPosition.position, Quaternion.identity);
            particle.Play();
        }
    }
}