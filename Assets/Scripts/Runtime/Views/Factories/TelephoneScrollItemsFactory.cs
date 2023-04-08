using System;
using NotEnoughMemory.Model;
using UnityEngine;
using Transform = UnityEngine.Transform;

namespace NotEnoughMemory.Factories
{
    public sealed class TelephoneScrollItemsFactory : MonoBehaviour, ITelephoneScrollItemsFactory
    {
        [SerializeField] private TelephoneScrollItem _prefab;
        [SerializeField] private Transform _content;
        
        public IScrollItem Create(ITelephoneData telephoneData)
        {
            if (telephoneData == null)
                throw new ArgumentNullException(nameof(telephoneData));

            TelephoneScrollItem item = Instantiate(_prefab, _content);
            item.Init(telephoneData);
            return item;
        }
    }
}