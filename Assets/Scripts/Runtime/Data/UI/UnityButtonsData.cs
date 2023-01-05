using NotEnoughMemory.UI;
using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class UnityButtonsData : MonoBehaviour, IUnityButtonsData
    {
        [SerializeField] private UnityButton _telephone;
        [SerializeField] private UnityButton _deleteAllSaves;
        [SerializeField] private UnityButton _music;
        
        public IUnityButton Telephone => _telephone;
        
        public IUnityButton DeleteAllSaves => _deleteAllSaves;
        
        public IUnityButton Music => _music;
    }
}