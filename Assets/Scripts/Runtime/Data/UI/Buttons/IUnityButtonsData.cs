﻿using NotEnoughMemory.UI;

namespace NotEnoughMemory.Root
{
    public interface IUnityButtonsData
    {
        IUnityButton Telephone { get; }
        
        IUnityButton DeleteAllSaves { get; }
        
        IUnityButton Music { get; }

    }
}