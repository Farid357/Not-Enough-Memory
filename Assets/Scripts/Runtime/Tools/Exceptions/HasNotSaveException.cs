using System;

namespace NotEnoughMemory.Model.Tools
{
    [Serializable]
    public sealed class HasNotSaveException : Exception
    {
        public HasNotSaveException(string message) : base($"Hasn't save for {message}")
        {
        }
    }
}