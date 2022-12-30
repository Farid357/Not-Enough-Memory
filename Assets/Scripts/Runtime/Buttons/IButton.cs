using UnityEngine.Events;

namespace NotEnoughMemory.UI
{
    public interface IButton
    {
        IButton Add(UnityAction clickAction);
    }
}