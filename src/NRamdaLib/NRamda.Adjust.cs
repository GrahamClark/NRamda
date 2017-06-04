using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static IEnumerable<T> Adjust<T>(
            this Func<T, T> func,
            int index,
            IEnumerable<T> collection)
        {
            // probably not ideal. Should be able to refine once there's a Reverse
            var list = collection.ToList();
            if (index < 0)
            {
                index = list.Count + index;
            }

            var i = 0;
            foreach (var item in list)
            {
                yield return i++ == index ? func(item) : item;
            }
        }

        public static Func<int, Func<IEnumerable<T>, IEnumerable<T>>> Adjust<T>(this Func<T, T> func)
        {
            return Curry<Func<T, T>, int, IEnumerable<T>, IEnumerable<T>>(Adjust)(func);
        }
    }
}
