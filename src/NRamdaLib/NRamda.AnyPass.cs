using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Takes a list of predicates and returns a function which tests if a given object 
        /// satisifies any predicate.
        /// </summary>
        /// <typeparam name="T">The type the predicates test.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T, bool> AnyPass<T>(this Func<T, bool>[] predicates)
        {
            return x =>
            {
                foreach (var predicate in predicates)
                {
                    if (predicate(x))
                    {
                        return true;
                    }
                }

                return false;
            };
        }

        /// <summary>
        /// Takes a list of two-arity predicates and returns a function which tests if a given object 
        /// satisifies any predicate.
        /// </summary>
        /// <typeparam name="T1">The type of the first predicate parameter.</typeparam>
        /// <typeparam name="T2">The type of the second predicate parameter.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T1, T2, bool> AnyPass<T1, T2>(this Func<T1, T2, bool>[] predicates)
        {
            return (x, y) =>
            {
                foreach (var predicate in predicates)
                {
                    if (predicate(x, y))
                    {
                        return true;
                    }
                }

                return false;
            };
        }

        /// <summary>
        /// Takes a list of three-arity predicates and returns a function which tests if a given object 
        /// satisifies any predicate.
        /// </summary>
        /// <typeparam name="T1">The type of the first predicate parameter.</typeparam>
        /// <typeparam name="T2">The type of the second predicate parameter.</typeparam>
        /// <typeparam name="T3">The type of the third predicate parameter.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T1, T2, T3, bool> AnyPass<T1, T2, T3>(
            this Func<T1, T2, T3, bool>[] predicates)
        {
            return (x, y, z) =>
            {
                foreach (var predicate in predicates)
                {
                    if (predicate(x, y, z))
                    {
                        return true;
                    }
                }

                return false;
            };
        }

        /// <summary>
        /// Takes a list of four-arity predicates and returns a function which tests if a given object 
        /// satisifies any predicate.
        /// </summary>
        /// <typeparam name="T1">The type of the first predicate parameter.</typeparam>
        /// <typeparam name="T2">The type of the second predicate parameter.</typeparam>
        /// <typeparam name="T3">The type of the third predicate parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth predicate parameter.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T1, T2, T3, T4, bool> AnyPass<T1, T2, T3, T4>(
            this Func<T1, T2, T3, T4, bool>[] predicates)
        {
            return (w, x, y, z) =>
            {
                foreach (var predicate in predicates)
                {
                    if (predicate(w, x, y, z))
                    {
                        return true;
                    }
                }

                return false;
            };
        }

        /// <summary>
        /// Takes a list of 2-arity predicates and returns a curried version of a function that
        /// tests the predicates to see if any are satisfied.
        /// </summary>
        /// <typeparam name="T1">The type of the first predicate parameter.</typeparam>
        /// <typeparam name="T2">The type of the second predicate parameter.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T1, Func<T2, bool>> AnyPassCurried<T1, T2>(
            this Func<T1, T2, bool>[] predicates)
        {
            return Curry(AnyPass(predicates));
        }

        /// <summary>
        /// Takes a list of 3-arity predicates and returns a curried version of a function that
        /// tests the predicates to see if any are satisfied.
        /// </summary>
        /// <typeparam name="T1">The type of the first predicate parameter.</typeparam>
        /// <typeparam name="T2">The type of the second predicate parameter.</typeparam>
        /// <typeparam name="T3">The type of the third predicate parameter.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T1, Func<T2, Func<T3, bool>>> AnyPassCurried<T1, T2, T3>(
            this Func<T1, T2, T3, bool>[] predicates)
        {
            return Curry(AnyPass(predicates));
        }

        /// <summary>
        /// Takes a list of 4-arity predicates and returns a curried version of a function that
        /// tests the predicates to see if any are satisfied.
        /// </summary>
        /// <typeparam name="T1">The type of the first predicate parameter.</typeparam>
        /// <typeparam name="T2">The type of the second predicate parameter.</typeparam>
        /// <typeparam name="T3">The type of the third predicate parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth predicate parameter.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T1, Func<T2, Func<T3, Func<T4, bool>>>> AnyPassCurried<T1, T2, T3, T4>(
            this Func<T1, T2, T3, T4, bool>[] predicates)
        {
            return Curry(AnyPass(predicates));
        }
    }
}
