using NotEnoughMemory.Model;
using UnityEngine;

namespace NotEnoughMemory.View
{
    public sealed class Effects : MonoBehaviour, IEffects
    {
        [SerializeField] private TelephonePressEffect _telephonePress;

        public ITelephonePressEffect TelephonePress => _telephonePress;

    }
}