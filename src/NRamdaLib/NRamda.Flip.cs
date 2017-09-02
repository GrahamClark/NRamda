using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Returns a new function much like the supplied one, 
        /// except that the first two arguments' order is reversed.
        /// </summary>
        /// <typeparam name="T1">The type of the function arguments.</typeparam>
        /// <typeparam name="T2">The return type of the function.</typeparam>
        /// <param name="func">The function.</param>
        public static Func<T1, T1, T2> Flip<T1, T2>(this Func<T1, T1, T2> func)
        {
            return (x, y) => func(y, x);
        }

        /// <summary>
        /// Returns a new function much like the supplied one, 
        /// except that the first two arguments' order is reversed.
        /// </summary>
        /// <typeparam name="T1">The type of the first two function arguments.</typeparam>
        /// <typeparam name="T2">The type of the third function argument.</typeparam>
        /// <typeparam name="T3">The return type of the function.</typeparam>
        /// <param name="func">The function.</param>
        public static Func<T1, T1, T2, T3> Flip<T1, T2, T3>(this Func<T1, T1, T2, T3> func)
        {
            return (x, y, z) => func(y, x, z);
        }

        /// <summary>
        /// Returns a new function much like the supplied one, 
        /// except that the first two arguments' order is reversed.
        /// </summary>
        /// <typeparam name="T1">The type of the first two function arguments.</typeparam>
        /// <typeparam name="T2">The type of the third function argument.</typeparam>
        /// <typeparam name="T3">The type of the fourth function argument.</typeparam>
        /// <typeparam name="T4">The return type of the function.</typeparam>
        /// <param name="func">The function.</param>
        public static Func<T1, T1, T2, T3, T4> Flip<T1, T2, T3, T4>(this Func<T1, T1, T2, T3, T4> func)
        {
            return (w, x, y, z) => func(x, w, y, z);
        }

        /// <summary>
        /// Returns a new, curried, function much like the supplied one, 
        /// except that the first two arguments' order is reversed.
        /// </summary>
        /// <typeparam name="T1">The type of the function arguments.</typeparam>
        /// <typeparam name="T2">The return type of the function.</typeparam>
        /// <param name="func">The function.</param>
        public static Func<T1, Func<T1, T2>> FlipCurried<T1, T2>(this Func<T1, T1, T2> func)
        {
            return x => y => func(y, x);
        }

        /// <summary>
        /// Returns a new, curried, function much like the supplied one, 
        /// except that the first two arguments' order is reversed.
        /// </summary>
        /// <typeparam name="T1">The type of the first two function arguments.</typeparam>
        /// <typeparam name="T2">The type of the third function argument.</typeparam>
        /// <typeparam name="T3">The return type of the function.</typeparam>
        /// <param name="func">The function.</param>
        public static Func<T1, Func<T1, Func<T2, T3>>> FlipCurried<T1, T2, T3>(
            this Func<T1, T1, T2, T3> func)
        {
            return x => y => z => func(y, x, z);
        }

        /// <summary>
        /// Returns a new, curried, function much like the supplied one, 
        /// except that the first two arguments' order is reversed.
        /// </summary>
        /// <typeparam name="T1">The type of the first two function arguments.</typeparam>
        /// <typeparam name="T2">The type of the third function argument.</typeparam>
        /// <typeparam name="T3">The type of the fourth function argument.</typeparam>
        /// <typeparam name="T4">The return type of the function.</typeparam>
        /// <param name="func">The function.</param>
        public static Func<T1, Func<T1, Func<T2, Func<T3, T4>>>> FlipCurried<T1, T2, T3, T4>(
            this Func<T1, T1, T2, T3, T4> func)
        {
            return w => x => y => z => func(x, w, y, z);
        }
    }
}
