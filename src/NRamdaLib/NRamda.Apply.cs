using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Takes a function that takes a collection (or params) as its argument, and a list of items,
        /// and uses the list as the function argument.
        /// </summary>
        /// <typeparam name="TList">The type of the list items.</typeparam>
        /// <typeparam name="TResult">The return type of the function</typeparam>
        /// <param name="variadic">The function.</param>
        /// <param name="list">The list.</param>
        /// <remarks>As C# doesn't really support variadic functions, this is a bit pointless.</remarks>
        public static TResult Apply<TList, TResult>(
            this Func<IEnumerable<TList>, TResult> variadic,
            IEnumerable<TList> list)
        {
            return variadic(list);
        }

        /// <summary>
        /// Takes a function that takes a collection (or params) as its argument, and a list of items,
        /// and uses the list as the function argument.
        /// </summary>
        /// <typeparam name="TList">The type of the list items.</typeparam>
        /// <typeparam name="TResult">The return type of the function</typeparam>
        /// <param name="variadic">The function.</param>
        /// <param name="list">The list.</param>
        public static TResult Apply<TList, TResult>(
            this Func<TList[], TResult> variadic,
            TList[] list)
        {
            return variadic(list);
        }

        /// <summary>
        /// Takes a function that takes a collection (or params) as its argument, and returns a
        /// function that takes list of items, and applies the list as the function argument.
        /// </summary>
        /// <typeparam name="TList">The type of the list items.</typeparam>
        /// <typeparam name="TResult">The return type of the function</typeparam>
        /// <param name="variadic">The function.</param>
        public static Func<IEnumerable<TList>, TResult> Apply<TList, TResult>(
            this Func<IEnumerable<TList>, TResult> variadic)
        {
            return Curry<Func<IEnumerable<TList>, TResult>, IEnumerable<TList>, TResult>(Apply)(
                variadic);
        }

        /// <summary>
        /// Takes a function that takes a collection (or params) as its argument, and returns a
        /// function that takes list of items, and applies the list as the function argument.
        /// </summary>
        /// <typeparam name="TList">The type of the list items.</typeparam>
        /// <typeparam name="TResult">The return type of the function</typeparam>
        /// <param name="variadic">The function.</param>
        public static Func<TList[], TResult> Apply<TList, TResult>(
            this Func<TList[], TResult> variadic)
        {
            return Curry<Func<TList[], TResult>, TList[], TResult>(Apply)(variadic);
        }
    }
}
