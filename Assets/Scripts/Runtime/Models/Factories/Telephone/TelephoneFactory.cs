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
        private readonly IUnity _unity;
        
        public TelephoneFactory(IGameLoop gameLoop, IUnity unity, IWallet wallet)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _unity = unity ?? throw new ArgumentNullException(nameof(unity));
        }
        
        public ITelephone Create()
        {
            IViews views = _unity.Views;
            ITelephone telephone = new Telephone(views.Telephone, new Memory(), views.Memory);
            IFactory<ITelephoneButton> telephoneButtonFactory = new TelephoneButtonFactory(views.Effects.TelephonePress, _wallet, 
                telephone, new Sound(views.Audios.TelephonePress));
            
            ITelephoneButton telephoneButton = telephoneButtonFactory.Create();
            _unity.UI.UnityButtons.Telephone.Init(telephoneButton);
            _gameLoop.LateGameUpdate.Add(telephone.Memory);
            return telephone;
        }
    }
}