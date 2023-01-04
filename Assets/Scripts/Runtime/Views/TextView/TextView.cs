using System;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.View
{
    public sealed class TextView : ITextView
    {
        private readonly IText _text;

        public TextView(IText text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }
        
        public void Visualize(string line)
        {
            _text.Visualize(line);
        }

        public void Visualize(int count)
        {
            _text.Visualize(count.ToString());
        }
    }
}