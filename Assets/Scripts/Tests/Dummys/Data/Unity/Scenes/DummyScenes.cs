﻿using NotEnoughMemory.Model;
using NotEnoughMemory.SceneLoading;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyScenes : IScenes
    {
        public IScene Menu => new DummyScene();
        
        public IScene Game => new DummyScene();
    }
}