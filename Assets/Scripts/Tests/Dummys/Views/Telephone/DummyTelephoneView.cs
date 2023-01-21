using System.Collections.Generic;
using NotEnoughMemory.Model;
using UnityEngine;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyTelephoneView : ITelephoneView
    {
        private readonly bool _readyToSwitchAppearance;

        public DummyTelephoneView(bool readyToSwitchAppearance)
        {
            _readyToSwitchAppearance = readyToSwitchAppearance;
        }

        public ITelephoneData CurrentData { get; } = ScriptableObject.CreateInstance<TelephoneData>();

        public IReadOnlyList<ITelephoneData> AllData => new List<ITelephoneData> { CurrentData };

        public bool ReadyToSwitchAppearance(int memoryFillingAmount)
        {
            return _readyToSwitchAppearance;
        }

        public void SwitchAppearance(int memoryFillingAmount)
        {
        }

        public void Break()
        {
        }

        public void Fix()
        {
        }
    }
}