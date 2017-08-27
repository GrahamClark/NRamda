using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static IEnumerable<T> Sort<T>(
            this Func<T, T, int> comparator,
            IEnumerable<T> collection)
        {
            var copy = collection.ToList();
            copy.Sort((x, y) => comparator(x, y));
            return copy;
        }

        public static IEnumerable<T> Sort<T>(
            this Comparison<T> comparator,
            IEnumerable<T> collection)
        {
            var copy = collection.ToList();
            copy.Sort(comparator);
            return copy;
        }

        public static Func<IEnumerable<T>, IEnumerable<T>> Sort<T>(this Func<T, T, int> comparator)
        {
            return Curry<Func<T, T, int>, IEnumerable<T>, IEnumerable<T>>(Sort)(comparator);
        }
    }
}
