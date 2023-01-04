using NotEnoughMemory.Factories;
using NotEnoughMemory.GameLoop;
using NotEnoughMemory.Model;
using NotEnoughMemory.Storage;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;
using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ViewData _viewData;
        private readonly IGameLoop _gameLoop = new GameLoop.GameLoop();

        private void Awake()
        {
            IFactory<ITelephone> telephoneFactory = new TelephoneFactory(_viewData.TelephoneView, _viewData.MemoryView, new Memory());
            var saveStorages = new SaveStorages(_gameLoop);
            var walletRoot = new WalletRoot(new TextView(_viewData.UI.Texts.Money), saveStorages);
            var wallet = walletRoot.Compose();
            IFactory<ITelephoneButton> telephoneButtonFactory = new TelephoneButtonFactory(_viewData.TelephoneClickEffect, wallet, telephoneFactory.Create());
            IRoot telephoneRoot = new TelephoneRoot(telephoneButtonFactory, _gameLoop, _viewData.UI.UnityButtons);
            telephoneRoot.Compose();
            saveStorages.Compose(wallet);
        }

        private void FixedUpdate()
        {
            _gameLoop.FixedUpdate(Time.fixedDeltaTime);
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _gameLoop.LateUpdate();
        }
    }
}