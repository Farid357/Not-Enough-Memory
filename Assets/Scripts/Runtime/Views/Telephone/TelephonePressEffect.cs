using System;
using NotEnoughMemory.View;
using UnityEngine;

namespace NotEnoughMemory.Model
{
    public sealed class TelephonePressEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private TelephoneView _telephoneView;
        [SerializeField] private UnityEngine.Transform _transform;
        
        private IEffect Effect => _telephoneView.CurrentData.Effect;

        public void Play()
        {
            Effect.PlayIn(new Transform(_transform.position, Quaternion.identity));
        }

        public void PlayIn(ITransform transform)
        {
            if (transform == null) 
                throw new ArgumentNullException(nameof(transform));
            
            Effect.PlayIn(transform);
        }
    }
}