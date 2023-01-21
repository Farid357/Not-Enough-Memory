using System;
using NotEnoughMemory.Model;
using Object = UnityEngine.Object;

namespace NotEnoughMemory.Factories
{
    public sealed class TelephoneScrollItemsFactory : ITelephoneScrollItemsFactory
    {
        private readonly ISpawnData<TelephoneScrollItem> _spawnData;

        public TelephoneScrollItemsFactory(ISpawnData<TelephoneScrollItem> spawnData)
        {
            _spawnData = spawnData ?? throw new ArgumentNullException(nameof(spawnData));

            if (_spawnData.HasParent() == false)
                throw new ArgumentOutOfRangeException($"For spawn {nameof(TelephoneScrollItemsFactory)} needs parent!");
        }

        public IScrollItem CreateFrom(ITelephoneData telephoneData)
        {
            TelephoneScrollItem scrollItem = Object.Instantiate(_spawnData.Prefab, _spawnData.Parent());
            scrollItem.Init(telephoneData);
            return scrollItem;
        }
    }
}