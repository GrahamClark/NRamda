using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static T2 Reduce<T1, T2>(
            Func<T2, T1, T2> func,
            T2 accumulator,
            IEnumerable<T1> collection)
        {
            foreach (var item in collection)
            {
                accumulator = func(accumulator, item);
            }

            return accumulator;
        }
    }
}
