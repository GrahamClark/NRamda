using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Returns a new copy of the collection with the element at the provided index 
        /// replaced with the given value.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="index">The index to update.</param>
        /// <param name="value">The new value.</param>
        /// <param name="collection">The collection.</param>
        public static IEnumerable<T> Update<T>(int index, T value, IEnumerable<T> collection)
        {
            var newCollection = collection.ToList();
            if (index < 0)
            {
                index = newCollection.Count + index;
            }

            if (index >= newCollection.Count || index < 0)
            {
                return newCollection;
            }

            newCollection[index] = value;

            return newCollection;
        }

        /// <summary>
        /// Takes an index and returns a curried version of Update.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="index">The index to update.</param>
        public static Func<T, Func<IEnumerable<T>, IEnumerable<T>>> Update<T>(int index)
        {
            return Curry<int, T, IEnumerable<T>, IEnumerable<T>>(Update)(index);
        }
    }
}
