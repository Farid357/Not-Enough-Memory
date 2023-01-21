using NotEnoughMemory.View;
using UnityEngine;

namespace NotEnoughMemory.Model
{
    public interface ITelephoneData
    {
        int NeedMemoryFillingAmount { get; }
        
        Sprite Icon { get; }
        
        string Name { get; }
        
        IEffect Effect { get; }
    }
}