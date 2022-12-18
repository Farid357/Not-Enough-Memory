using UnityEngine.Events;

namespace NotEnoughMemory.UI
{
    public interface IButton
    {
        Button Add(UnityAction clickAction);
    }
}