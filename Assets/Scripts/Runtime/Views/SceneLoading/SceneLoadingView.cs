using System;
using NotEnoughMemory.View;

namespace NotEnoughMemory.SceneLoading
{
    public sealed class SceneLoadingView : ISceneLoadingView
    {
        private readonly IScrollBar _scrollBar;
        private readonly ITextView _textView;

        public SceneLoadingView(IScrollBar scrollBar, ITextView textView)
        {
            _scrollBar = scrollBar ?? throw new ArgumentNullException(nameof(scrollBar));
            _textView = textView ?? throw new ArgumentNullException(nameof(textView));
        }
        
        public void Visualize(float progress)
        {
            _textView.Visualize(progress.ToString());
            _scrollBar.Visualize(progress);
        }
    }
}