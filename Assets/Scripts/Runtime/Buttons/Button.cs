using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NotEnoughMemory.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public sealed class Button : MonoBehaviour, IButton
    {
        private readonly List<UnityAction> _clickActions = new();
        private UnityEngine.UI.Button _button;

        public void Init()
        {
            _button = GetComponent<UnityEngine.UI.Button>();
        }

        public Button Add(UnityAction clickAction)
        {
            if (clickAction == null)
                throw new ArgumentNullException(nameof(clickAction));

            _button.onClick.AddListener(clickAction);
            _clickActions.Add(clickAction);
            return this;
        }

        private void OnDestroy()
        {
            foreach (var clickAction in _clickActions)
            {
                _button.onClick.RemoveListener(clickAction);
            }
            
            _clickActions.Clear();
        }
    }
}