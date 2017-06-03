using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static IEnumerable<T> Adjust<T>(
            this Func<T, T> func,
            int index,
            IEnumerable<T> collection)
        {
            var newList = new List<T>();
            var i = 0;
            foreach (var item in collection)
            {
                yield return i++ == index ? func(item) : item;
            }
        }
    }
}
