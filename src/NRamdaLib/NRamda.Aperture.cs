using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static IEnumerable<IEnumerable<T>> Aperture<T>(this int n, IEnumerable<T> collection)
        {
            var list = collection.ToList();
            if (n > list.Count)
            {
                return Enumerable.Empty<IEnumerable<T>>();
            }

            return ApertureInternal(n, list);
        }

        public static Func<IEnumerable<T>, IEnumerable<IEnumerable<T>>> Aperture<T>(this int n)
        {
            return Curry<int, IEnumerable<T>, IEnumerable<IEnumerable<T>>>(Aperture)(n);
        }

        private static IEnumerable<IEnumerable<T>> ApertureInternal<T>(int n, List<T> list)
        {
            int index = 0;
            int limit = list.Count - (n - 1);
            while (index < limit)
            {
                yield return list.Skip(index).Take(n);
                index += 1;
            }
        }
    }
}
