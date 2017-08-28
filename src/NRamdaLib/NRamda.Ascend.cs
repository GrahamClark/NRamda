using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Makes a <see cref="Comparison{T}"/> delegate from a function.
        /// </summary>
        /// <typeparam name="T">The type of items to compare.</typeparam>
        /// <param name="func">The comparator function.</param>
        /// <remarks>Another one that seems quite pointless in C#.</remarks>
        public static Comparison<T> Ascend<T>(Func<T, T, int> func)
        {
            return (x, y) => func(x, y);
        }

        /// <summary>
        /// Makes a <see cref="Comparison{T}"/> delegate from a predicate.
        /// </summary>
        /// <typeparam name="T">The type of items to compare.</typeparam>
        /// <param name="func">The predicate.</param>
        public static Comparison<T> Ascend<T>(Func<T, int> func)
        {
            return (x, y) => func(x);
        }
    }
}
