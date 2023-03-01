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
        private readonly IGameLoopObjects _gameLoopObjects;
        private readonly ITelephoneView _telephoneView;
        private readonly ITelephoneScrollItemsFactory _scrollItemsFactory;

        public TelephoneScrollViewFactory(IGameLoopObjects gameLoopObjects, ITelephoneView telephoneView, ITelephoneScrollItemsFactory scrollItemsFactory)
        {
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
            _telephoneView = telephoneView ?? throw new ArgumentNullException(nameof(telephoneView));
            _scrollItemsFactory = scrollItemsFactory ?? throw new ArgumentNullException(nameof(scrollItemsFactory));
        }

        public ITelephonesScrollView Create()
        {
            IPath telephoneSavesPath = new Path("Telephone Saves");
            ISaveStorage<List<TelephoneSaveData>> telephoneSaveDataStorage = new BinaryStorage<List<TelephoneSaveData>>(telephoneSavesPath);
            var telephonesScrollView = new TelephonesScrollView(_telephoneView, _scrollItemsFactory, telephoneSaveDataStorage);
            _gameLoopObjects.Add(telephonesScrollView);
            return telephonesScrollView;
        }
    }
}