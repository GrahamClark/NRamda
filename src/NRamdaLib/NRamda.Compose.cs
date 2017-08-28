using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Performs right-to-left function composition.
        /// </summary>
        /// <typeparam name="T1">The input type to the first function.</typeparam>
        /// <typeparam name="T2">The return type of the first function, and input type of the second function.</typeparam>
        /// <typeparam name="T3">The return type of the second function.</typeparam>
        /// <param name="second">The second function to compose.</param>
        /// <param name="first">The first function to compose.</param>
        public static Func<T1, T3> Compose<T1, T2, T3>(Func<T2, T3> second, Func<T1, T2> first)
        {
            return x => second(first(x));
        }

        /// <summary>
        /// Performs right-to-left function composition.
        /// </summary>
        /// <typeparam name="T1">The first input type to the first function.</typeparam>
        /// <typeparam name="T2">The second input type to the first function.</typeparam>
        /// <typeparam name="T3">The return type of the first function, and input type of the second function.</typeparam>
        /// <typeparam name="T4">The return type of the second function.</typeparam>
        /// <param name="second">The second function to compose.</param>
        /// <param name="first">The first function to compose.</param>
        public static Func<T1, T2, T4> Compose<T1, T2, T3, T4>(
            Func<T3, T4> second,
            Func<T1, T2, T3> first)
        {
            return (x, y) => second(first(x, y));
        }

        /// <summary>
        /// Performs right-to-left function composition.
        /// </summary>
        /// <typeparam name="T1">The first input type to the first function.</typeparam>
        /// <typeparam name="T2">The second input type to the first function.</typeparam>
        /// <typeparam name="T3">The third input type to the first function.</typeparam>
        /// <typeparam name="T4">The return type of the first function, and input type of the second function.</typeparam>
        /// <typeparam name="T5">The return type of the second function.</typeparam>
        /// <param name="second">The second function to compose.</param>
        /// <param name="first">The first function to compose.</param>
        public static Func<T1, T2, T3, T5> Compose<T1, T2, T3, T4, T5>(
            Func<T4, T5> second,
            Func<T1, T2, T3, T4> first)
        {
            return (x, y, z) => second(first(x, y, z));
        }

        /// <summary>
        /// Performs right-to-left function composition.
        /// </summary>
        /// <typeparam name="T1">The input type to the first function.</typeparam>
        /// <typeparam name="T2">The return type of the first function, and input type of the second function.</typeparam>
        /// <typeparam name="T3">The return type of the second function, and input type of the third function.</typeparam>
        /// <typeparam name="T4">The return type of the third function.</typeparam>
        /// <param name="third">The third function to compose.</param>
        /// <param name="second">The second function to compose.</param>
        /// <param name="first">The first function to compose.</param>
        public static Func<T1, T4> Compose<T1, T2, T3, T4>(
            Func<T3, T4> third,
            Func<T2, T3> second,
            Func<T1, T2> first)
        {
            return x => third(second(first(x)));
        }

        /// <summary>
        /// Performs right-to-left function composition.
        /// </summary>
        /// <typeparam name="T1">The first input type to the first function.</typeparam>
        /// <typeparam name="T2">The second input type to the first function.</typeparam>
        /// <typeparam name="T3">The return type of the first function, and input type of the second function.</typeparam>
        /// <typeparam name="T4">The return type of the second function, and input type of the third function.</typeparam>
        /// <typeparam name="T5">The return type of the third function.</typeparam>
        /// <param name="third">The third function to compose.</param>
        /// <param name="second">The second function to compose.</param>
        /// <param name="first">The first function to compose.</param>
        public static Func<T1, T2, T5> Compose<T1, T2, T3, T4, T5>(
            Func<T4, T5> third,
            Func<T3, T4> second,
            Func<T1, T2, T3> first)
        {
            return (x, y) => third(second(first(x, y)));
        }

        /// <summary>
        /// Performs right-to-left function composition.
        /// </summary>
        /// <typeparam name="T1">The first input type to the first function.</typeparam>
        /// <typeparam name="T2">The second input type to the first function.</typeparam>
        /// <typeparam name="T3">The third input type to the first function.</typeparam>
        /// <typeparam name="T4">The return type of the first function, and input type of the second function.</typeparam>
        /// <typeparam name="T5">The return type of the second function, and input type of the third function.</typeparam>
        /// <typeparam name="T6">The return type of the third function.</typeparam>
        /// <param name="third">The third function to compose.</param>
        /// <param name="second">The second function to compose.</param>
        /// <param name="first">The first function to compose.</param>
        public static Func<T1, T2, T3, T6> Compose<T1, T2, T3, T4, T5, T6>(
            Func<T5, T6> third,
            Func<T4, T5> second,
            Func<T1, T2, T3, T4> first)
        {
            return (x, y, z) => third(second(first(x, y, z)));
        }

        /// <summary>
        /// Performs right-to-left function composition.
        /// </summary>
        /// <typeparam name="T1">The input type to the first function.</typeparam>
        /// <typeparam name="T2">The return type of the first function, and input type of the second function.</typeparam>
        /// <typeparam name="T3">The return type of the second function, and input type of the third function.</typeparam>
        /// <typeparam name="T4">The return type of the third function, and input type of the fourth function.</typeparam>
        /// <typeparam name="T5">The return type of the fourth function.</typeparam>
        /// <param name="fourth">The fourth function to compose.</param>
        /// <param name="third">The third function to compose.</param>
        /// <param name="second">The second function to compose.</param>
        /// <param name="first">The first function to compose.</param>
        public static Func<T1, T5> Compose<T1, T2, T3, T4, T5>(
            Func<T4, T5> fourth,
            Func<T3, T4> third,
            Func<T2, T3> second,
            Func<T1, T2> first)
        {
            return x => fourth(third(second(first(x))));
        }

        /// <summary>
        /// Performs right-to-left function composition.
        /// </summary>
        /// <typeparam name="T1">The first input type to the first function.</typeparam>
        /// <typeparam name="T2">The second input type to the first function.</typeparam>
        /// <typeparam name="T3">The return type of the first function, and input type of the second function.</typeparam>
        /// <typeparam name="T4">The return type of the second function, and input type of the third function.</typeparam>
        /// <typeparam name="T5">The return type of the third function, and input type of the fourth function.</typeparam>
        /// <typeparam name="T6">The return type of the fourth function.</typeparam>
        /// <param name="fourth">The fourth function to compose.</param>
        /// <param name="third">The third function to compose.</param>
        /// <param name="second">The second function to compose.</param>
        /// <param name="first">The first function to compose.</param>
        public static Func<T1, T2, T6> Compose<T1, T2, T3, T4, T5, T6>(
            Func<T5, T6> fourth,
            Func<T4, T5> third,
            Func<T3, T4> second,
            Func<T1, T2, T3> first)
        {
            return (x, y) => fourth(third(second(first(x, y))));
        }

        /// <summary>
        /// Performs right-to-left function composition.
        /// </summary>
        /// <typeparam name="T1">The first input type to the first function.</typeparam>
        /// <typeparam name="T2">The second input type to the first function.</typeparam>
        /// <typeparam name="T3">The third input type to the first function.</typeparam>
        /// <typeparam name="T4">The return type of the first function, and input type of the second function.</typeparam>
        /// <typeparam name="T5">The return type of the second function, and input type of the third function.</typeparam>
        /// <typeparam name="T6">The return type of the third function, and input type of the fourth function.</typeparam>
        /// <typeparam name="T7">The return type of the fourth function.</typeparam>
        /// <param name="fourth">The fourth function to compose.</param>
        /// <param name="third">The third function to compose.</param>
        /// <param name="second">The second function to compose.</param>
        /// <param name="first">The first function to compose.</param>
        public static Func<T1, T2, T3, T7> Compose<T1, T2, T3, T4, T5, T6, T7>(
            Func<T6, T7> fourth,
            Func<T5, T6> third,
            Func<T4, T5> second,
            Func<T1, T2, T3, T4> first)
        {
            return (x, y, z) => fourth(third(second(first(x, y, z))));
        }
    }
}
