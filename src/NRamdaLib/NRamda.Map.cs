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
    }
}
