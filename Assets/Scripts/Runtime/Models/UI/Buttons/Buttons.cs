using System;
using System.Collections.Generic;

namespace NotEnoughMemory.UI
{
    public sealed class Buttons : IButton
    {
        private readonly IEnumerable<IButton> _buttons;

        public Buttons(params IButton[] buttons)
        {
            _buttons = buttons ?? throw new ArgumentNullException(nameof(buttons));
        }

        public void Press()
        {
            foreach (var button in _buttons)
            {
                button.Press();
            }
        }
    }
}