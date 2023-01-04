using System;
using NotEnoughMemory.Factories;
using NotEnoughMemory.GameLoop;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Root
{
    public sealed class TelephoneRoot : IRoot
    {
        private readonly IFactory<ITelephoneButton> _telephoneButtonFactory;
        private readonly IUnityButtonsData _unityButtons;
        private readonly IGameLoop _gameLoop;

        public TelephoneRoot(IFactory<ITelephoneButton> telephoneButtonFactory, IGameLoop gameLoop, IUnityButtonsData unityButtons)
        {
            _telephoneButtonFactory = telephoneButtonFactory ?? throw new ArgumentNullException(nameof(telephoneButtonFactory));
            _unityButtons = unityButtons ?? throw new ArgumentNullException(nameof(unityButtons));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }
        
        public void Compose()
        {
            ITelephoneButton telephoneButton = _telephoneButtonFactory.Create();
            _unityButtons.Telephone.Init(telephoneButton);
            var telephone = telephoneButton.Telephone;
            _gameLoop.GameUpdate.Add(telephone);
            _gameLoop.LateGameUpdate.Add(telephone.Memory);
        }
    }
}