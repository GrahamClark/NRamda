using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static IEnumerable<T> Map<T>(this Func<T, T> func, IEnumerable<T> list)
        {
            return list.Select(func);
        }

        public static Func<IEnumerable<T>, IEnumerable<T>> Map<T>(this Func<T, T> func)
        {
            return Curry<Func<T, T>, IEnumerable<T>, IEnumerable<T>>(Map)(func);
        }
    }
}
