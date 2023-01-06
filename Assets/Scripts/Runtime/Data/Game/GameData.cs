using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Model;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Game
{
    public sealed class GameData : IGameData
    {
        public GameData(IViewData view, IUIData ui, IScenesData scenes, IAudioData audio)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
            UI = ui ?? throw new ArgumentNullException(nameof(ui));
            Scenes = scenes ?? throw new ArgumentNullException(nameof(scenes));
            Audio = audio ?? throw new ArgumentNullException(nameof(audio));
        }

        public IViewData View { get; }

        public IUIData UI { get; }

        public IScenesData Scenes { get; }

        public IAudioData Audio { get; }
    }
}