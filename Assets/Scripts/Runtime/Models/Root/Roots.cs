using System;
using System.Collections.Generic;

namespace NotEnoughMemory.Root
{
    public sealed class Roots : IRoot
    {
        private readonly IReadOnlyList<IRoot> _all;

        public Roots(IReadOnlyList<IRoot> all)
        {
            _all = all ?? throw new ArgumentNullException(nameof(all));
        }


        public void Compose()
        {
            foreach (var root in _all)
            {
                root.Compose();
            }
        }
    }
}