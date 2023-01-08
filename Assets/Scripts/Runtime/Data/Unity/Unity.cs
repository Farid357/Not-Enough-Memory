using System;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.Model;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Game
{
    public sealed class Unity : IGameEngine
    {
        public Unity(IViews views, IUI ui, IScenes scenes)
        {
            Views = views ?? throw new ArgumentNullException(nameof(views));
            UI = ui ?? throw new ArgumentNullException(nameof(ui));
            Scenes = scenes ?? throw new ArgumentNullException(nameof(scenes));
        }

        public IViews Views { get; }

        public IUI UI { get; }

        public IScenes Scenes { get; }
    }
}