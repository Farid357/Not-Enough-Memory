using System;
using NotEnoughMemory.Factories;
using NotEnoughMemory.GameLoop;
using NotEnoughMemory.Model;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Root
{
    public sealed class TelephoneRoot : IRoot
    {
        private readonly ITelephone _telephone;
        private readonly ITelephoneClickEffect _telephoneClickEffect;
        private readonly IGameLoop _gameLoop;
        private readonly IButton _telephoneButton;

        public TelephoneRoot(IFactory<ITelephone> telephoneFactory, IGameLoop gameLoop, ITelephoneClickEffect telephoneClickEffect, IButton telephoneButton)
        {
            _telephoneClickEffect = telephoneClickEffect ?? throw new ArgumentNullException(nameof(telephoneClickEffect));
            _telephoneButton = telephoneButton ?? throw new ArgumentNullException(nameof(telephoneButton));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _telephone = telephoneFactory.Create();
        }
        
        public void Compose()
        {
            _telephoneButton.Init();
            IButtonClickAction telephoneCLickAction = new TelephoneClickAction(_telephone, _telephoneClickEffect);
            _telephoneButton.Add(telephoneCLickAction);
            _gameLoop.GameUpdate.Add(_telephone);
            _gameLoop.LateGameUpdate.Add(_telephone.Memory);
        }
    }
}