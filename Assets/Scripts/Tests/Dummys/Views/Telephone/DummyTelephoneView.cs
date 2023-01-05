﻿using NotEnoughMemory.Model;
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

        public ITelephoneData Data => ScriptableObject.CreateInstance<TelephoneData>();

        public bool ReadyToSwitchAppearance(int memoryFillingAmount)
        {
            return _readyToSwitchAppearance;
        }

        public void SwitchAppearance(int memoryFillingAmount)
        {

        }

        public void SwitchAppearanceToBroken()
        {
            
        }

        public void SwitchAppearanceToFixed()
        {
            
        }
    }
}