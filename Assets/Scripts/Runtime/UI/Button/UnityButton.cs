﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace NotEnoughMemory.UI
{
    [RequireComponent(typeof(Button))]
    public sealed class UnityButton : MonoBehaviour, IGameEngineButton
    {
        private IButton _button;
        private Button _unityButton;
        
        public void Init(IButton button)
        {
            _button = button ?? throw new ArgumentNullException(nameof(button));
            _unityButton = GetComponent<Button>();
            _unityButton.onClick.AddListener(button.Press);
        }

        private void OnDestroy()
        {
            if (_button != null)
                _unityButton.onClick.RemoveListener(_button.Press);
        }
    }
}