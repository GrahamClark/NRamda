using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Returns a function that always returns the given value.
        /// </summary>
        /// <typeparam name="T">The type to return.</typeparam>
        /// <param name="value">The value to return.</param>
        public static Func<T> Always<T>(T value)
        {
            return () => value;
        }

        /// <summary>
        /// Returns a function that takes a parameter and always returns the given value.
        /// </summary>
        /// <typeparam name="T1">The type to return.</typeparam>
        /// <typeparam name="T2">The type of the function parameter.</typeparam>
        /// <param name="value">The value to return.</param>
        public static Func<T2, T1> Always<T1, T2>(T1 value)
        {
            return x => value;
        }

        /// <summary>
        /// Returns a curried 2-arity function that always returns the given value.
        /// </summary>
        /// <typeparam name="T1">The type to return.</typeparam>
        /// <typeparam name="T2">The type of the first function parameter.</typeparam>
        /// <typeparam name="T3">The type of the second function parameter.</typeparam>
        /// <param name="value">The value to return.</param>
        public static Func<T2, Func<T3, T1>> Always<T1, T2, T3>(T1 value)
        {
            return Curry<T2, T3, T1>((x, y) => value);
        }
    }
}
