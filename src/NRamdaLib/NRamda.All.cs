using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static bool All<T>(this Func<T, bool> predicate, IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static Func<IEnumerable<T>, bool> All<T>(this Func<T, bool> predicate)
        {
            return Curry<Func<T, bool>, IEnumerable<T>, bool>(All)(predicate);
        }
    }
}
