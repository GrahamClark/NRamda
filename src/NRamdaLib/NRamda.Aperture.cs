using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Returns a new collection, composed of n-tuples of consecutive elements. 
        /// If <paramref name="n"/> is greater than the length of <paramref name="collection"/>, 
        /// an empty list is returned.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="n">The number of elements in each tuple.</param>
        /// <param name="collection">The collection.</param>
        public static IEnumerable<IEnumerable<T>> Aperture<T>(this int n, IEnumerable<T> collection)
        {
            var list = collection.ToList();
            if (n > list.Count)
            {
                return Enumerable.Empty<IEnumerable<T>>();
            }

            return ApertureInternal(n, list);
        }

        /// <summary>
        /// Takes a number and returns a function that takes a collection and 
        /// returns a new collection, composed of n-tuples of consecutive elements. 
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="n">The number of elements in each tuple.</param>
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
