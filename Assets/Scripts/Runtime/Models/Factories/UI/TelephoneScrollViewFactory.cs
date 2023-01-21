using System;
using System.Collections.Generic;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.Model;
using NotEnoughMemory.Storage;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Factories
{
    public sealed class TelephoneScrollViewFactory : ITelephoneScrollViewFactory
    {
        private readonly IGameUpdate _gameUpdate;
        private readonly ITelephoneView _telephoneView;
        private readonly ITelephoneScrollItemsFactory _scrollItemsFactory;

        public TelephoneScrollViewFactory(IGameUpdate gameUpdate, ITelephoneView telephoneView, ITelephoneScrollItemsFactory scrollItemsFactory)
        {
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
            _telephoneView = telephoneView ?? throw new ArgumentNullException(nameof(telephoneView));
            _scrollItemsFactory = scrollItemsFactory ?? throw new ArgumentNullException(nameof(scrollItemsFactory));
        }

        public ITelephonesScrollView Create()
        {
            IPath telephoneSavesPath = new Path("Telephone Saves");
            ISaveStorage<List<TelephoneSaveData>> telephoneSaveDataStorage = new BinaryStorage<List<TelephoneSaveData>>(telephoneSavesPath);
            var telephonesScrollView = new TelephonesScrollView(_telephoneView, _scrollItemsFactory, telephoneSaveDataStorage);
            _gameUpdate.Add(telephonesScrollView);
            return telephonesScrollView;
        }
    }
}