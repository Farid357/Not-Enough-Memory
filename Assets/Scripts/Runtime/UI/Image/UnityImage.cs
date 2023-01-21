using System;
using NotEnoughMemory.Model;
using UnityEngine;
using UnityEngine.UI;

namespace NotEnoughMemory.UI
{
    public sealed class UnityImage : IGameEngineImage
    {
        private readonly Image _image;

        public UnityImage(Image image, IGameObjectWithTransform gameObject)
        {
            _image = image ?? throw new ArgumentNullException(nameof(image));
            GameObject = gameObject ?? throw new ArgumentNullException(nameof(gameObject));
        }
        
        public IGameObjectWithTransform GameObject { get; }
        
        public void Visualize(Sprite sprite)
        {
            _image.sprite = sprite ?? throw new ArgumentNullException(nameof(sprite));
        }

        public void ClearSprite()
        {
            _image.sprite = null;
        }
    }
}