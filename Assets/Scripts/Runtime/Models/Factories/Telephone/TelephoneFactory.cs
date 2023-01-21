using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Game;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.Model;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Factories
{
    public sealed class TelephoneFactory : IFactory<ITelephone>
    {
        private readonly IWallet _wallet;
        private readonly IGameLoop _gameLoop;
        private readonly IGameEngine _gameEngine;
        
        public TelephoneFactory(IGameLoop gameLoop, IGameEngine gameEngine, IWallet wallet)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _gameEngine = gameEngine ?? throw new ArgumentNullException(nameof(gameEngine));
        }
        
        public ITelephone Create()
        {
            IViews views = _gameEngine.Views;
            ITelephoneView telephoneView = views.Telephone;
            ITelephone telephone = new Telephone(telephoneView, new Memory(), views.Memory);
            IAudio telephonePressSound = new Sound(views.Audios.TelephonePress);
            IFactory<ITelephoneButton> telephoneButtonFactory = new TelephoneButtonFactory(views.Effects.TelephonePress, _wallet, 
                telephone, telephonePressSound);
            
            ITelephoneButton telephoneButton = telephoneButtonFactory.Create();
            _gameEngine.UI.GameEngineButtons.Telephone.Init(telephoneButton);
            _gameLoop.LateGameUpdate.Add(telephone.Memory);
            return telephone;
        }
    }
}