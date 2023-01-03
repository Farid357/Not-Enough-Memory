using System;
using NotEnoughMemory.Factories;
using NotEnoughMemory.Model;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Root
{
    public sealed class TelephoneRoot : IRoot
    {
        private readonly ITelephone _telephone;
        private readonly ITelephoneClickEffect _telephoneClickEffect;
        private readonly IGameUpdate _gameUpdate;
        private readonly IButton _telephoneButton;

        public TelephoneRoot(IFactory<ITelephone> telephoneFactory, IGameUpdate gameUpdate, ITelephoneClickEffect telephoneClickEffect)
        {
            _telephoneClickEffect = telephoneClickEffect ?? throw new ArgumentNullException(nameof(telephoneClickEffect));
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
            _telephone = telephoneFactory.Create();
        }
        
        public void Compose()
        {
            _telephoneButton.Init();
            IButtonClickAction telephoneCLickAction = new TelephoneClickAction(_telephone, _telephoneClickEffect);
            _telephoneButton.Add(telephoneCLickAction);
            _gameUpdate.SystemUpdate.Add(_telephone);
            _gameUpdate.LateSystemUpdate.Add(_telephone.Memory);
        }
    }
}