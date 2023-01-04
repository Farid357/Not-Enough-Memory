using System;

namespace NotEnoughtMemory.Model.Tools
{
    [Serializable]
    public sealed class HasNotSaveException : Exception
    {
        public HasNotSaveException(string message) : base($"Hasn't save for {message}")
        {
        }
    }
}