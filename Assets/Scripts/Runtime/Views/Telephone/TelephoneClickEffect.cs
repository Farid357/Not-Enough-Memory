using System;
using UnityEngine;

namespace NotEnoughMemory.Model
{
    public sealed class TelephoneClickEffect : MonoBehaviour, ITelephoneClickEffect
    {
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private TelephoneView _telephoneView;

        private ParticleSystem ParticlePrefab => _telephoneView.Data.ParticlePrefab;
        
        public void Play()
        {
            var particle = Instantiate(ParticlePrefab, _spawnPosition.position, Quaternion.identity);
            particle.Play();
        }
    }
}