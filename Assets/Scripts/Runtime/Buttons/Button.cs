using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NotEnoughMemory.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public sealed class Button : MonoBehaviour, IButton
    {
        private readonly IList<IButtonClickAction> _clickActions = new List<IButtonClickAction>();
        private UnityEngine.UI.Button _button;

        public void Init()
        {
            _button = GetComponent<UnityEngine.UI.Button>();
        }

        public IButton Add(IButtonClickAction clickAction)
        {
            if (clickAction == null)
                throw new ArgumentNullException(nameof(clickAction));

            _button.onClick.AddListener(clickAction.OnClick);
            _clickActions.Add(clickAction);
            return this;
        }

        private void OnDestroy()
        {
            foreach (var clickAction in _clickActions)
            {
                _button.onClick.RemoveListener(clickAction.OnClick);
            }
            
            _clickActions.Clear();
        }
    }
}