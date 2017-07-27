using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            foreach (var item in first)
            {
                yield return item;
            }

            foreach (var item in second)
            {
                yield return item;
            }
        }

        public static Func<IEnumerable<T>, IEnumerable<T>> Concat<T>(this IEnumerable<T> first)
        {
            return Curry<IEnumerable<T>, IEnumerable<T>, IEnumerable<T>>(Concat)(first);
        }

        public static string Concat(this string first, string second)
        {
            return first + second;
        }

        public static Func<string, string> Concat(this string first)
        {
            return Curry<string, string, string>(Concat)(first);
        }
    }
}
