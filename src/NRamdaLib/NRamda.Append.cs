using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static IEnumerable<T> Append<T>(this T item, IEnumerable<T> list)
        {
            foreach (var listItem in list)
            {
                yield return listItem;
            }

            yield return item;
        }

        public static Func<IEnumerable<T>, IEnumerable<T>> Append<T>(this T item)
        {
            return Curry<T, IEnumerable<T>, IEnumerable<T>>(Append)(item);
        }
    }
}
