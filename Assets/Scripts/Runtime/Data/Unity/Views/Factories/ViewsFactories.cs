using NotEnoughMemory.Factories;
using NotEnoughMemory.Model;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NotEnoughMemory.View
{
    public sealed class ViewsFactories : SerializedMonoBehaviour, IViewsFactories
    {
        [SerializeField] private TelephoneScrollItemsFactory _telephoneScrollItemsFactory;

        public ITelephoneScrollItemsFactory TelephoneScrollItemsFactory => _telephoneScrollItemsFactory;
    }
}