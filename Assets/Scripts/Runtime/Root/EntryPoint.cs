using NotEnoughMemory.Factories;
using NotEnoughMemory.GameLoop;
using NotEnoughMemory.Model;
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
            IRoot telephoneRoot = new TelephoneRoot(telephoneFactory, _gameLoop, _viewData.TelephoneClickEffect, _viewData.Buttons.Telephone);
            telephoneRoot.Compose();
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