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
            IView view = _unity.View;
            ITelephone telephone = new Telephone(view.Telephone, new Memory(), view.Memory);
            IFactory<ITelephoneButton> telephoneButtonFactory = new TelephoneButtonFactory(view.TelephonePressEffect, _wallet, 
                telephone, new Sound(_unity.Audio.TelephonePress));
            
            ITelephoneButton telephoneButton = telephoneButtonFactory.Create();
            _unity.UI.UnityButtons.Telephone.Init(telephoneButton);
            _gameLoop.LateGameUpdate.Add(telephone.Memory);
            return telephone;
        }
    }
}