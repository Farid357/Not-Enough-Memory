using NotEnoughMemory.Factories;
using NotEnoughMemory.GameLoop;
using NotEnoughMemory.Model;
using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ViewData _viewData;
        private GameUpdate _gameUpdate;

        private void Awake()
        {
            _gameUpdate = new GameUpdate(new LateSystemUpdate(), new FixedSystemUpdate(), new SystemUpdate());
            IFactory<ITelephone> telephoneFactory = new TelephoneFactory(_viewData.TelephoneView, _viewData.MemoryView, new Memory());
            IRoot telephoneRoot = new TelephoneRoot(telephoneFactory, _gameUpdate, _viewData.TelephoneClickEffect);
            telephoneRoot.Compose();
        }

        private void FixedUpdate()
        {
            _gameUpdate.FixedUpdate(Time.fixedDeltaTime);
        }

        private void Update()
        {
            _gameUpdate.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _gameUpdate.LateUpdate(Time.deltaTime);
        }
    }
}