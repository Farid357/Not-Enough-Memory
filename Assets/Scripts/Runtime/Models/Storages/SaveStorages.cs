using System;
using System.Collections.Generic;
using NotEnoughMemory.GameLoop;
using NotEnoughMemory.Model;

namespace NotEnoughMemory.Storage
{
    public sealed class SaveStorages : ISaveStorages
    {
        private readonly IGameLoop _gameLoop;
        private readonly List<ICanDeleteSaveStorage> _all = new();
        
        public ISaveStorage<Money> Money { get; }

        public SaveStorages(IGameLoop gameLoop)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            Money = new BinaryStorage<Money>(new PathWithNames<IWallet, Money>());
            _all.Add(Money);
        }
        
        public void DeleteAllSaves()
        {
            foreach (var storage in _all)
            {
                if (storage.HasSave())
                    storage.DeleteSave();
            }
        }

    }
}