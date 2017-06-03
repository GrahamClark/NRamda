using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static Func<Func<T, int, IEnumerable<T>, T>, IEnumerable<T>, IEnumerable<T>> AddIndex<T>(
            this Func<Func<T, T>, IEnumerable<T>, IEnumerable<T>> mapFunc)
        {
            return (func, collection) =>
            {
                var list = collection.ToList();
                int index = 0;
                var newList = new List<T>();
                foreach (var item in list)
                {
                    // can't have "yield return" in anonymous method,
                    // so need to build up a new list
                    newList.Add(func(item, index++, list));
                }

                return newList;
            };
        }
    }
}
