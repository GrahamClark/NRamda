using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
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

        public static Func<IEnumerable<T>, IEnumerable<T>> Ap<T>(
            IEnumerable<Func<T, T>> functions)
        {
            return Curry<IEnumerable<Func<T, T>>, IEnumerable<T>, IEnumerable<T>>(Ap)(functions);
        }
    }
}
