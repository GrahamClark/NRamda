using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static bool Any<T>(this Func<T, bool> predicate, IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static Func<IEnumerable<T>, bool> Any<T>(this Func<T, bool> predicate)
        {
            return Curry<Func<T, bool>, IEnumerable<T>, bool>(Any)(predicate);
        }
    }
}
