using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Game;
using NotEnoughMemory.Model;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Factories
{
    public sealed class TelephoneFactory : IFactory<ITelephone>
    {
        private readonly IWallet _wallet;
        private readonly IGameEngine _gameEngine;
        
        public TelephoneFactory(IGameEngine gameEngine, IWallet wallet)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _gameEngine = gameEngine ?? throw new ArgumentNullException(nameof(gameEngine));
        }
        
        public ITelephone Create()
        {
            IViews views = _gameEngine.Views;
            ITelephoneView telephoneView = views.Telephone;
            ITelephone telephone = new Telephone(telephoneView, new Memory(), views.Memory);
            IAudio telephonePressSound = new Sound(views.Audios.TelephonePress);
            IFactory<IButton> telephoneButtonFactory = new TelephoneButtonFactory(views.Effects.TelephonePress, _wallet, 
                telephone, telephonePressSound);
            
            IButton telephoneButton = telephoneButtonFactory.Create();
            _gameEngine.UI.GameEngineButtons.Telephone.Init(telephoneButton);
            return telephone;
        }
    }
}