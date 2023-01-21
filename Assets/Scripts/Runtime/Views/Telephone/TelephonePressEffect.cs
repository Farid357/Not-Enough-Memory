using System;
using NotEnoughMemory.View;
using UnityEngine;

namespace NotEnoughMemory.Model
{
    public sealed class TelephonePressEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private TelephoneView _telephoneView;
        [SerializeField] private Transform _transform;
        
        private IEffect Effect => _telephoneView.CurrentData.Effect;

        public void Play()
        {
            Effect.PlayIn(new ConstantTransformData(_transform.position, Quaternion.identity));
        }

        public void PlayIn(ITransformData transform)
        {
            if (transform == null) 
                throw new ArgumentNullException(nameof(transform));
            
            Effect.PlayIn(transform);
        }
    }
}