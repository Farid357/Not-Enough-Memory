using System;
using System.Collections.Generic;
using NotEnoughMemory.Factories;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.Model;
using NotEnoughMemory.Model.Tools;
using NotEnoughMemory.Storage;

namespace NotEnoughMemory.View
{
    public sealed class TelephonesScrollView : IUpdateable, ITelephonesScrollView
    {
        private readonly ITelephoneView _telephoneView;
        private readonly ITelephoneScrollItemsFactory _factory;
        private readonly ISaveStorage<List<TelephoneSaveData>> _telephoneDataStorage;
        private readonly List<TelephoneSaveData> _telephoneSaveData = new();
        private readonly List<ITelephoneData> _usedTelephoneData = new();

        public TelephonesScrollView(ITelephoneView telephoneView, ITelephoneScrollItemsFactory factory, ISaveStorage<List<TelephoneSaveData>> telephoneDataStorage)
        {
            _telephoneView = telephoneView ?? throw new ArgumentNullException(nameof(telephoneView));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _telephoneDataStorage = telephoneDataStorage ?? throw new ArgumentNullException(nameof(telephoneDataStorage));

            if (_telephoneDataStorage.HasSave())
                _telephoneSaveData = _telephoneDataStorage.Load();
        }

        public void Enable()
        {
            foreach (var telephoneSaveData in _telephoneSaveData)
            {
                ITelephoneData telephoneData = telephoneSaveData.FindSameFrom(_telephoneView.AllData);
                _factory.CreateFrom(telephoneData).Visualize();
                _usedTelephoneData.Add(telephoneData);
            }
        }
        
        public void Update(float deltaTime)
        {
            ITelephoneData currentData = _telephoneView.CurrentData;

            if (_usedTelephoneData.Contains(currentData) == false)
            {
                _usedTelephoneData.Add(currentData);
                var telephoneSaveData = new TelephoneSaveData(currentData.Name, currentData.Icon.name, currentData.NeedMemoryFillingAmount);
                _telephoneSaveData.Add(telephoneSaveData);
                _factory.CreateFrom(currentData).Visualize();
                _telephoneDataStorage.Save(_telephoneSaveData);
            }
        }
    }
}