using UnityEngine;

namespace NotEnoughMemory.UI
{
    public sealed class ExitGameButton : IButton
    {
        public void Press()
        {
            Application.Quit();
        }
    }
}