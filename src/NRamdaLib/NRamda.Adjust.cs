using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Applies a function to the item at a specified index in the collection, 
        /// returning a new collection containing the modified value.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="func">The function to modify a collection item.</param>
        /// <param name="index">The index at which to apply the function.</param>
        /// <param name="collection">The input collection.</param>
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

        /// <summary>
        /// Takes a function and returns a function which takes an index and returns a function
        /// which takes a collection, and applies the first function to the item at the specified index. 
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="func">The function to modify a collection item.</param>
        public static Func<int, Func<IEnumerable<T>, IEnumerable<T>>> Adjust<T>(this Func<T, T> func)
        {
            return Curry<Func<T, T>, int, IEnumerable<T>, IEnumerable<T>>(Adjust)(func);
        }
    }
}
