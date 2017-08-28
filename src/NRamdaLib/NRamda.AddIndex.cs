using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Takes a map function and adds two parameters to its callback function, 
        /// the current index and the entire list.
        /// </summary>
        /// <typeparam name="T">The type of the list items.</typeparam>
        /// <param name="mapFunc">The map function.</param>
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
                    // can't have "yield return" in an anonymous method,
                    // so need to build up a new list
                    newList.Add(func(item, index++, list));
                }

                return newList;
            };
        }

        /// <summary>
        /// Takes a list accumulator function and adds two parameters to its callback function, 
        /// the current index and the entire list.
        /// </summary>
        /// <typeparam name="T1">The type of the list items.</typeparam>
        /// <typeparam name="T2">The type of the accumulator result.</typeparam>
        /// <param name="accFunc">The accumulator function.</param>
        public static Func<Func<T2, T1, int, IEnumerable<T1>, T2>, T2, IEnumerable<T1>, T2>
            AddIndex<T1, T2>(
                this Func<Func<T2, T1, T2>, T2, IEnumerable<T1>, T2> accFunc)
        {
            return (func, acc, collection) =>
            {
                int index = 0;
                var list = collection.ToList();
                foreach (var item in list)
                {
                    acc = func(acc, item, index++, list);
                }

                return acc;
            };
        }

        /// <summary>
        /// Takes a map function and adds two parameters to its callback function, 
        /// the current index and the entire list.
        /// </summary>
        /// <typeparam name="T">The type of the list items.</typeparam>
        /// <param name="mapFunc">The map function.</param>
        public static Func<Func<T, int, IEnumerable<T>, T>, Func<IEnumerable<T>, IEnumerable<T>>>
            AddIndexCurried<T>(
                this Func<Func<T, T>, IEnumerable<T>, IEnumerable<T>> mapFunc)
        {
            // only varies by return type, so have to have a separate curreied version
            return func =>
                collection =>
                {
                    var list = collection.ToList();
                    int index = 0;
                    var newList = new List<T>();
                    foreach (var item in list)
                    {
                        // can't have "yield return" in an nonymous method,
                        // so need to build up a new list
                        newList.Add(func(item, index++, list));
                    }

                    return newList;
                };
        }

        /// <summary>
        /// Takes a list accumulator function and adds two parameters to its callback function, 
        /// the current index and the entire list.
        /// </summary>
        /// <typeparam name="T1">The type of the list items.</typeparam>
        /// <typeparam name="T2">The type of the accumulator result.</typeparam>
        /// <param name="accFunc">The accumulator function.</param>
        public static Func<Func<T2, T1, int, IEnumerable<T1>, T2>, Func<T2, IEnumerable<T1>, T2>>
            AddIndexCurried<T1, T2>(
                this Func<Func<T2, T1, T2>, T2, IEnumerable<T1>, T2> accFunc)
        {
            return func =>
                (acc, collection) =>
                {
                    int index = 0;
                    var list = collection.ToList();
                    foreach (var item in list)
                    {
                        acc = func(acc, item, index++, list);
                    }

                    return acc;
                };
        }
    }
}
