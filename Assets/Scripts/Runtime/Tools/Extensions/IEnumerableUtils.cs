using System;
using System.Collections.Generic;
using System.Linq;

namespace NotEnoughMemory.Model.Tools
{
    public static class IEnumerableUtils
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (var item in enumerable)
            {
                action.Invoke(item);
            }
        }
    }
}