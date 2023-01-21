using NotEnoughMemory.Model;
using UnityEngine;

namespace NotEnoughMemory.UI
{
    public interface IGameEngineImage
    {
        IGameObjectWithTransform GameObject { get; }
        
        void Visualize(Sprite sprite);

        void ClearSprite();

    }
}