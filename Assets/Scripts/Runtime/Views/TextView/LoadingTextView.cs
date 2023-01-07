using System;

namespace NotEnoughMemory.View
{
    public sealed class LoadingTextView : ITextView
    {
        private readonly ITextView _textView;

        public LoadingTextView(ITextView textView)
        {
            _textView = textView ?? throw new ArgumentNullException(nameof(textView));
        }

        public void Visualize(string line)
        {
            var trimLine = line.Length > 2 ? line[..1] : line;
            _textView.Visualize(trimLine + "%");
        }

        public void Visualize(int count)
        {
            string line = count.ToString();
            Visualize(line);
        }
    }
}