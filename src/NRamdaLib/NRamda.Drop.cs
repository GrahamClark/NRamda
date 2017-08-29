using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Returns all but the first <paramref name="count"/> elements of the given list.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="count">The number of items to drop.</param>
        /// <param name="collection">The collection.</param>
        public static IEnumerable<T> Drop<T>(int count, IEnumerable<T> collection)
        {
            var index = 0;
            foreach (var item in collection)
            {
                index += 1;
                if (index > count)
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Returns all but the first <paramref name="count"/> characters in a string.
        /// </summary>
        /// <param name="count">The number of characters to drop.</param>
        /// <param name="s">The string.</param>
        public static string Drop(int count, string s)
        {
            return new string(Drop<char>(count, s).ToArray());
        }

        /// <summary>
        /// Returns a function that takes a collection and returns all but the first
        /// <paramref name="count"/> items from it.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="count">The number of elements to drop.</param>
        public static Func<IEnumerable<T>, IEnumerable<T>> Drop<T>(int count)
        {
            return Curry<int, IEnumerable<T>, IEnumerable<T>>(Drop)(count);
        }
    }
}
