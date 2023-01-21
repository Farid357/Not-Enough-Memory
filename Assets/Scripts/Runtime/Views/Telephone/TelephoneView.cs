using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NotEnoughMemory.Model
{
    public sealed class TelephoneView : MonoBehaviour, ITelephoneView
    {
        [SerializeField] private List<TelephoneData> _data;
        [SerializeField] private Image _image;
        private int _dataIndex;
        
        public ITelephoneData CurrentData => _data[_dataIndex];
        
        public IReadOnlyList<ITelephoneData> AllData => _data;

        public bool ReadyToSwitchAppearance(int memoryFillingAmount)
        {
            if (memoryFillingAmount < 0) 
                throw new ArgumentOutOfRangeException(nameof(memoryFillingAmount));
            
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
            _image.sprite = appearanceData.Icon;
        }

        public void Break()
        {
            _image.sprite = _data[_dataIndex].BrokenIcon;
        }
        
        public void Fix()
        {
            _image.sprite = CurrentData.Icon;
        }
    }
}