using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Returns the first <paramref name="count"/> elements in a collection.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="count">The number of elements to take.</param>
        /// <param name="collection">The collection.</param>
        public static IEnumerable<T> Take<T>(int count, IEnumerable<T> collection)
        {
            var index = 0;
            foreach (var item in collection)
            {
                if (index == count)
                {
                    break;
                }

                yield return item;
                index += 1;
            }
        }

        /// <summary>
        /// Returns the first <paramref name="count"/> characters in a string.
        /// </summary>
        /// <param name="count">The number of characters to take.</param>
        /// <param name="s">The string.</param>
        public static string Take(int count, string s)
        {
            return s.Substring(0, count);
        }

        /// <summary>
        /// Returns a function that takes a collection and returns the first
        /// <paramref name="count"/> items from it.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="count">The number of elements to take.</param>
        public static Func<IEnumerable<T>, IEnumerable<T>> Take<T>(int count)
        {
            return Curry<int, IEnumerable<T>, IEnumerable<T>>(Take)(count);
        }
    }
}
