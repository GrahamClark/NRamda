using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Tests if no item in a collection satisfies a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="predicate">The predicate to apply to the collection items.</param>
        /// <param name="collection">The collection to test.</param>
        public static bool None<T>(this Func<T, bool> predicate, IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Takes a predicate and returns a function which takes a collection to apply the predicate to
        /// and tests if no item in the collection satisfies the predicate.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="predicate">The predicate.</param>
        public static Func<IEnumerable<T>, bool> None<T>(this Func<T, bool> predicate)
        {
            return Curry<Func<T, bool>, IEnumerable<T>, bool>(All)(predicate);
        }
    }
}
