using System;
using System.Collections.Generic;
using NotEnoughtMemory.Model.Tools.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace NotEnoughMemory.Model
{
    public sealed class TelephoneView : MonoBehaviour, ITelephoneView
    {
        [SerializeField] private List<TelephoneData> _data;
        [SerializeField] private Image _image;
        [SerializeField] private TelephoneClickEffect _clickEffect;

        private int _dataIndex;
        
        public TelephoneData Data => _data[_dataIndex];
        
        public bool ReadyToSwitchAppearance(int memoryFillingAmount)
        {
            memoryFillingAmount.TryThrowLessThanOrEqualsToZeroException();
            
            if (_dataIndex + 1 == _data.Count)
                return false;
            
            return _data[_dataIndex].NeedMemoryFillingAmount <= memoryFillingAmount;
        }

        public void SwitchAppearance(int memoryFillingAmount)
        {
            if (ReadyToSwitchAppearance(memoryFillingAmount) == false)
                throw new InvalidOperationException("Can't to change appearance!");

            _dataIndex++;
            TelephoneData appearanceData = _data[_dataIndex];
            _clickEffect.SwitchPrefab(appearanceData.ParticlePrefab);
            _image.sprite = appearanceData.Icon;
        }
    }
}