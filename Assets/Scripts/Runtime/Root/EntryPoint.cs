using NotEnoughMemory.Audio;
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
        [SerializeField] private ViewData _view;
        [SerializeField] private UIData _ui;
        [SerializeField] private AudioData _audio;
        
        private readonly IGameLoop _gameLoop = new GameLoop.GameLoop();

        private void Awake()
        {
            IFactory<ITelephone> telephoneFactory = new TelephoneFactory(_view.TelephoneView, _view.MemoryView, new Memory());
            ISaveStorages saveStorages = new SaveStorages(_gameLoop);
            IFactory<IWallet> walletFactory = new WalletFactory(new TextView(_ui.Texts.Money), saveStorages);
            IWallet wallet = walletFactory.Create();
            ITelephone telephone = telephoneFactory.Create();
            IFactory<ITelephoneButton> telephoneButtonFactory = new TelephoneButtonFactory(_view.TelephonePressEffect, wallet, telephone, _audio.TelephonePress);
            IRoot telephoneRoot = new TelephoneRoot(telephoneButtonFactory, _gameLoop, _ui.UnityButtons);
            IRoot settingsRoot = new SettingsRoot(_ui.UnityButtons, saveStorages, new Music(_audio.Music));
            settingsRoot.Compose();
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