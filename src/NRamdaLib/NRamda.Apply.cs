using System;
using System.Collections.Generic;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static TResult Apply<TList, TResult>(
            this Func<IEnumerable<TList>, TResult> variadic,
            IEnumerable<TList> list)
        {
            return variadic(list);
        }

        public static TResult Apply<TList, TResult>(
            this Func<TList[], TResult> variadic,
            TList[] list)
        {
            return variadic(list);
        }

        public static Func<IEnumerable<TList>, TResult> Apply<TList, TResult>(
            this Func<IEnumerable<TList>, TResult> variadic)
        {
            return Curry<Func<IEnumerable<TList>, TResult>, IEnumerable<TList>, TResult>(Apply)(
                variadic);
        }

        public static Func<TList[], TResult> Apply<TList, TResult>(
            this Func<TList[], TResult> variadic)
        {
            return Curry<Func<TList[], TResult>, TList[], TResult>(Apply)(variadic);
        }
    }
}
