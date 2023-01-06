using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Model;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Game
{
    public sealed class Unity : IUnity
    {
        public Unity(IView view, IUI ui, IScenes scenes, IAudioData audio)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
            UI = ui ?? throw new ArgumentNullException(nameof(ui));
            Scenes = scenes ?? throw new ArgumentNullException(nameof(scenes));
            Audio = audio ?? throw new ArgumentNullException(nameof(audio));
        }

        public IView View { get; }

        public IUI UI { get; }

        public IScenes Scenes { get; }

        public IAudioData Audio { get; }
    }
}