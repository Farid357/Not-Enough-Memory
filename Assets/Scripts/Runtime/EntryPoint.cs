using NotEnoughMemory.Audio;
using NotEnoughMemory.Factories;
using NotEnoughMemory.Game;
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
        private IGame _game;

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
            IRoot inputRoot = new InputRoot(_ui.Windows, _gameLoop.GameUpdate);
            IRoot roots = new Roots(new[] { inputRoot, settingsRoot, telephoneRoot });
            _game = new Game.Game(roots, new GameTime());
            _game.Play();
        }

        private void FixedUpdate()
        {
            if (_game.IsNotPaused)
                _gameLoop.FixedUpdate(Time.fixedDeltaTime);
        }

        private void Update()
        {
            if (_game.IsNotPaused)
                _gameLoop.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            if (_game.IsNotPaused)
                _gameLoop.LateUpdate();
        }
    }
}