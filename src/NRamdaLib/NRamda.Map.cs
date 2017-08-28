using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Takes a function and a functor, applies the function to each of the functor's values, 
        /// and returns a functor of the same shape.
        /// </summary>
        /// <typeparam name="T">The type of the functor items.</typeparam>
        /// <param name="func">The function.</param>
        /// <param name="list">The functor.</param>
        public static IEnumerable<T> Map<T>(this Func<T, T> func, IEnumerable<T> list)
        {
            return list.Select(func);
        }

        /// <summary>
        /// Takes a function, and returns a function that takes a functor and applies the function 
        /// to each of the functor's values, and returns a functor of the same shape.
        /// </summary>
        /// <typeparam name="T">The type of the functor items.</typeparam>
        /// <param name="func">The function.</param>
        public static Func<IEnumerable<T>, IEnumerable<T>> Map<T>(this Func<T, T> func)
        {
            return Curry<Func<T, T>, IEnumerable<T>, IEnumerable<T>>(Map)(func);
        }
    }
}
