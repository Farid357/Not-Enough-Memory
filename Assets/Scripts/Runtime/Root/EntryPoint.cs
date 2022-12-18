using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Root[] _roots;
        
        private void Awake()
        {
            foreach (var root in _roots)
            {
                root.Compose();
            }    
        }
    }
}