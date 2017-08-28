using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Takes a comparator function and a collection and returns a new collection, sorted using 
        /// the comparator.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="comparator">The comparator function.</param>
        /// <param name="collection">The collection.</param>
        public static IEnumerable<T> Sort<T>(
            this Func<T, T, int> comparator,
            IEnumerable<T> collection)
        {
            var copy = collection.ToList();
            copy.Sort((x, y) => comparator(x, y));
            return copy;
        }

        /// <summary>
        /// Takes a comparator function and a collection and returns a new collection, sorted using 
        /// the comparator.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="comparator">The comparator function.</param>
        /// <param name="collection">The collection.</param>
        public static IEnumerable<T> Sort<T>(
            this Comparison<T> comparator,
            IEnumerable<T> collection)
        {
            var copy = collection.ToList();
            copy.Sort(comparator);
            return copy;
        }

        /// <summary>
        /// Takes a comparator function and returns a function that takes a collection and returns
        /// a new, sorted collection.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="comparator">The comparator function.</param>
        public static Func<IEnumerable<T>, IEnumerable<T>> Sort<T>(this Func<T, T, int> comparator)
        {
            return Curry<Func<T, T, int>, IEnumerable<T>, IEnumerable<T>>(Sort)(comparator);
        }
    }
}
