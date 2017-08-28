using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Applies a collection of functions to a collection of values.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="functions">The functions to apply.</param>
        /// <param name="input">The collection.</param>
        public static IEnumerable<T> Ap<T>(IEnumerable<Func<T, T>> functions, IEnumerable<T> input)
        {
            var list = input.ToList();
            foreach (var function in functions)
            {
                foreach (var item in list)
                {
                    yield return function(item);
                }
            }
        }

        /// <summary>
        /// Takes a collection of functions and returns a function which takes a collection of items
        /// and applies each function to each item.
        /// </summary>
        /// <typeparam name="T">The type of the collection items.</typeparam>
        /// <param name="functions">The functions to apply.</param>
        public static Func<IEnumerable<T>, IEnumerable<T>> Ap<T>(
            IEnumerable<Func<T, T>> functions)
        {
            return Curry<IEnumerable<Func<T, T>>, IEnumerable<T>, IEnumerable<T>>(Ap)(functions);
        }
    }
}
