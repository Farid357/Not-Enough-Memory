using System;

namespace NotEnoughMemory.SceneLoading
{
    public interface IScreenFade
    {
        event Action OnDarkened;

        void FadeIn();

        void FadeOut();
    }
}