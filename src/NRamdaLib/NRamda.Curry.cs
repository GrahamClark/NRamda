using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Returns a curried equivalent of the provided function.
        /// </summary>
        /// <typeparam name="T1">The first input type of the function.</typeparam>
        /// <typeparam name="T2">The second input type of the function.</typeparam>
        /// <typeparam name="T3">The return type of the function.</typeparam>
        /// <param name="func">The function.</param>
        public static Func<T1, Func<T2, T3>> Curry<T1, T2, T3>(this Func<T1, T2, T3> func)
        {
            return x => y => func(x, y);
        }

        /// <summary>
        /// Returns a curried equivalent of the provided function.
        /// </summary>
        /// <typeparam name="T1">The first input type of the function.</typeparam>
        /// <typeparam name="T2">The second input type of the function.</typeparam>
        /// <typeparam name="T3">The third input type of the function.</typeparam>
        /// <typeparam name="T4">The return type of the function.</typeparam>
        /// <param name="func">The function.</param>
        public static Func<T1, Func<T2, Func<T3, T4>>> Curry<T1, T2, T3, T4>(
            this Func<T1, T2, T3, T4> func)
        {
            return x => y => z => func(x, y, z);
        }

        /// <summary>
        /// Returns a curried equivalent of the provided function.
        /// </summary>
        /// <typeparam name="T1">The first input type of the function.</typeparam>
        /// <typeparam name="T2">The second input type of the function.</typeparam>
        /// <typeparam name="T3">The third input type of the function.</typeparam>
        /// <typeparam name="T4">The fourth input type of the function.</typeparam>
        /// <typeparam name="T5">The return type of the function.</typeparam>
        /// <param name="func">The function.</param>
        public static Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> Curry<T1, T2, T3, T4, T5>(
            this Func<T1, T2, T3, T4, T5> func)
        {
            return w => x => y => z => func(w, x, y, z);
        }
    }
}
