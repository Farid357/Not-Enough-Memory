using System;
using UnityEngine;

namespace NotEnoughMemory.Model
{
    public sealed class TelephoneClickEffect : MonoBehaviour, ITelephoneClickEffect
    {
        [SerializeField] private Transform _spawnPosition;
        private ITelephoneView _telephoneView;

        private ParticleSystem ParticlePrefab => _telephoneView.Data.ParticlePrefab;
        
        public void Init(ITelephoneView telephoneView)
        {
            _telephoneView = telephoneView ?? throw new ArgumentNullException(nameof(telephoneView));
        }

        public void Play()
        {
            var particle = Instantiate(ParticlePrefab, _spawnPosition.position, Quaternion.identity);
            particle.Play();
        }
    }
}