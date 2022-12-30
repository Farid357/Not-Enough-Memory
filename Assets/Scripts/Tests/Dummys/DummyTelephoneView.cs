using NotEnoughMemory.Model;
using UnityEngine;

namespace NotEnoughMemory.Tests
{
    public sealed class DummyTelephoneView : ITelephoneView
    {
        private readonly bool _readyToSwitchAppearance;

        public DummyTelephoneView(bool readyToSwitchAppearance)
        {
            _readyToSwitchAppearance = readyToSwitchAppearance;
        }

        public ITelephoneData Data => ScriptableObject.CreateInstance<TelephoneData>();

        public bool ReadyToSwitchAppearance(int memoryFillingAmount)
        {
            return _readyToSwitchAppearance;
        }

        public void SwitchAppearance(int memoryFillingAmount)
        {

        }
    }
}