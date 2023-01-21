using System;
using NotEnoughMemory.Model;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NotEnoughMemory.Factories
{
    public sealed class MonoTelephoneScrollItemsFactory : SerializedMonoBehaviour, ITelephoneScrollItemsFactory
    {
        [SerializeField] private SpawnData<TelephoneScrollItem> _spawnData;

        public IScrollItem CreateFrom(ITelephoneData telephoneData)
        {
            if (telephoneData == null)
                throw new ArgumentNullException(nameof(telephoneData));
            
            ITelephoneScrollItemsFactory scrollItemsFactory = new TelephoneScrollItemsFactory(_spawnData);
            return scrollItemsFactory.CreateFrom(telephoneData);
        }
    }
}