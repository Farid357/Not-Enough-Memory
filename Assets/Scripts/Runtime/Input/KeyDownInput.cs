using UnityEngine;

namespace NotEnoughMemory.Input
{
    public sealed class KeyDownInput : IKeyDownInput
    {
        private readonly KeyCode _key;

        public KeyDownInput(KeyCode key)
        {
            _key = key;
        }

        public bool WasUsed()
        {
            return UnityEngine.Input.GetKeyDown(_key);
        }
    }
}