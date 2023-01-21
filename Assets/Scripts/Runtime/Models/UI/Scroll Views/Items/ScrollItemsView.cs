using System;
using System.Collections.Generic;

namespace NotEnoughMemory.UI
{
    public sealed class ScrollItemsView : IScrollItemView
    {
        private readonly List<IScrollItemView> _all;

        public ScrollItemsView(List<IScrollItemView> all)
        {
            _all = all ?? throw new ArgumentNullException(nameof(all));
        }

        public void Visualize()
        {
            _all.ForEach(scrollItem => scrollItem.Visualize());
        }
    }
}