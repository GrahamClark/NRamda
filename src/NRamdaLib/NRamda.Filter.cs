using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Takes a predicate and a collection, and returns a new collection 
        /// containing the members of the original collection which satisfy the given predicate.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="collection">The collection.</param>
        public static IEnumerable<T> Filter<T>(
            this Func<T, bool> predicate,
            IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Takes a predicate and a dictionary, and returns a new dictionary 
        /// containing the members of the original dictionary which satisfy the given predicate.
        /// </summary>
        /// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
        /// <typeparam name="TValue">The type of the dictionary values.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="dictionary">The dictionary.</param>
        public static IDictionary<TKey, TValue> Filter<TKey, TValue>(
            this Func<TValue, bool> predicate,
            IDictionary<TKey, TValue> dictionary)
        {
            var newDict= new Dictionary<TKey, TValue>();
            foreach (var kvp in dictionary)
            {
                if (predicate(kvp.Value))
                {
                    newDict.Add(kvp.Key, kvp.Value);
                }
            }

            return newDict;
        }

        /// <summary>
        /// Takes a predicate and returns a function which takes a collection and returns
        /// a new collection filtered by the predicate.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="predicate">The predicate.</param>
        public static Func<IEnumerable<T>, IEnumerable<T>> Filter<T>(this Func<T, bool> predicate)
        {
            return Curry<Func<T, bool>, IEnumerable<T>, IEnumerable<T>>(Filter)(predicate);
        }

        /// <summary>
        /// Takes a predicate and returns a function which takes a dictionary and returns
        /// a new dictionary filtered by the predicate.
        /// </summary>
        /// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
        /// <typeparam name="TValue">The type of the dictionary values.</typeparam>
        /// <param name="predicate">The predicate.</param>
        public static Func<IDictionary<TKey, TValue>, IDictionary<TKey, TValue>>
            Filter<TKey, TValue>(this Func<TValue, bool> predicate)
        {
            return Curry<Func<TValue, bool>, IDictionary<TKey, TValue>, IDictionary<TKey, TValue>>(
                Filter)(predicate);
        }
    }
}
