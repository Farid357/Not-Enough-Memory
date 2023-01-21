using System;
using Object = UnityEngine.Object;

namespace NotEnoughMemory.Model
{
    public sealed class GameObject : IGameObjectWithTransform
    {
        private readonly UnityEngine.GameObject _gameObject;

        public GameObject(UnityEngine.GameObject gameObject, ITransformData transform)
        {
            _gameObject = gameObject ?? throw new ArgumentNullException(nameof(gameObject));
            Transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public ITransformData Transform { get; }
        
        public bool IsActive { get; private set; }
        
        public void Destroy()
        {
            IsActive = false;
            Object.Destroy(_gameObject);
        }

        public void Enable()
        {
            if (IsActive)
                throw new InvalidOperationException("Game Object is already enabled!");
            
            _gameObject.SetActive(true);
            IsActive = true;
        }

        public void Disable()
        {
            if (IsActive == false)
                throw new InvalidOperationException("Game Object is already disabled!");

            IsActive = false;
            _gameObject.SetActive(false);
        }
    }
}