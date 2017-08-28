using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Returns a new collection containing the elements of the given collection, 
        /// followed by the given item.
        /// </summary>
        /// <typeparam name="T">The type of the collection elements.</typeparam>
        /// <param name="item">The item to append.</param>
        /// <param name="list">The original collection.</param>
        public static IEnumerable<T> Append<T>(this T item, IEnumerable<T> list)
        {
            foreach (var listItem in list)
            {
                yield return listItem;
            }

            yield return item;
        }

        /// <summary>
        /// Takes an item to append and returns a function that takes a collection and returns
        /// a new collection containing its elements followed by the item.
        /// </summary>
        /// <typeparam name="T">The type of the collection elements.</typeparam>
        /// <param name="item">The item to append.</param>
        public static Func<IEnumerable<T>, IEnumerable<T>> Append<T>(this T item)
        {
            return Curry<T, IEnumerable<T>, IEnumerable<T>>(Append)(item);
        }
    }
}
