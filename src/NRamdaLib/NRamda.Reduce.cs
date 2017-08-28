using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Returns a single item by iterating through a collection, successively calling the iterator 
        /// function and passing it an accumulator value and the current value from the collection, 
        /// and then passing the result to the next call.
        /// </summary>
        /// <typeparam name="T1">The type of the collection itmes.</typeparam>
        /// <typeparam name="T2">The type of the accumulator.</typeparam>
        /// <param name="func">The iterator function.</param>
        /// <param name="accumulator">The accumulator.</param>
        /// <param name="collection">The collection.</param>
        public static T2 Reduce<T1, T2>(
            this Func<T2, T1, T2> func,
            T2 accumulator,
            IEnumerable<T1> collection)
        {
            foreach (var item in collection)
            {
                accumulator = func(accumulator, item);
            }

            return accumulator;
        }

        /// <summary>
        /// Takes an iterator function and returns a curried Reduce function.
        /// </summary>
        /// <typeparam name="T1">The type of the collection itmes.</typeparam>
        /// <typeparam name="T2">The type of the accumulator.</typeparam>
        /// <param name="func">The iterator function.</param>
        public static Func<T2, Func<IEnumerable<T1>, T2>> Reduce<T1, T2>(
            this Func<T2, T1, T2> func)
        {
            return Curry<Func<T2, T1, T2>, T2, IEnumerable<T1>, T2>(Reduce)(func);
        }
    }
}
