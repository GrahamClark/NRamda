using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Concatenates two collections.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="first">The first collection.</param>
        /// <param name="second">The second collection.</param>
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

        /// <summary>
        /// Takes a collection and returns a function that takes another collection and
        /// concatenates the two.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="first">The first collection.</param>
        public static Func<IEnumerable<T>, IEnumerable<T>> Concat<T>(this IEnumerable<T> first)
        {
            return Curry<IEnumerable<T>, IEnumerable<T>, IEnumerable<T>>(Concat)(first);
        }

        /// <summary>
        /// Concatenates two strings.
        /// </summary>
        /// <param name="first">The first string.</param>
        /// <param name="second">The second string.</param>
        public static string Concat(this string first, string second)
        {
            return first + second;
        }

        /// <summary>
        /// Takes a string and returns a function that takes another string and
        /// concatenates the two.
        /// </summary>
        /// <param name="first">The first string.</param>
        public static Func<string, string> Concat(this string first)
        {
            return Curry<string, string, string>(Concat)(first);
        }
    }
}
