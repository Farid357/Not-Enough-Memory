using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Game;
using NotEnoughMemory.GameLoop;
using NotEnoughMemory.Model;
using NotEnoughMemory.Root;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Factories
{
    public sealed class TelephoneFactory : IFactory<ITelephone>
    {
        private readonly IWallet _wallet;
        private readonly IGameLoop _gameLoop;
        private readonly IGameData _game;
        
        public TelephoneFactory(IGameLoop gameLoop, IGameData gameData, IWallet wallet)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _game = gameData ?? throw new ArgumentNullException(nameof(gameData));
        }
        
        public ITelephone Create()
        {
            IViewData view = _game.View;
            ITelephone telephone = new Telephone(view.Telephone, new Memory(), view.Memory);
            IFactory<ITelephoneButton> telephoneButtonFactory = new TelephoneButtonFactory(view.TelephonePressEffect, _wallet, 
                telephone, new Sound(_game.Audio.TelephonePress));
            
            ITelephoneButton telephoneButton = telephoneButtonFactory.Create();
            _game.UI.UnityButtons.Telephone.Init(telephoneButton);
            _gameLoop.LateGameUpdate.Add(telephone.Memory);
            return telephone;
        }
    }
}