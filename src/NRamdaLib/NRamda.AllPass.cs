using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Takes a list of predicates and returns a function which tests if a given object 
        /// satisifies each predicate.
        /// </summary>
        /// <typeparam name="T">The type the predicates test.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T, bool> AllPass<T>(this Func<T, bool>[] predicates)
        {
            return x =>
            {
                foreach (var predicate in predicates)
                {
                    if (!predicate(x))
                    {
                        return false;
                    }
                }

                return true;
            };
        }

        /// <summary>
        /// Takes a list of two-arity predicates and returns a function which tests if a given object 
        /// satisifies each predicate.
        /// </summary>
        /// <typeparam name="T1">The type of the first predicate parameter.</typeparam>
        /// <typeparam name="T2">The type of the second predicate parameter.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T1, T2, bool> AllPass<T1, T2>(this Func<T1, T2, bool>[] predicates)
        {
            // Really difficult to take an array of arbitrary-arity predicates.
            // A custom delegate can be defined, but then everything needs to be
            // defined in terms of this instead of being able to use implicit 
            // "casting" to Func<..., bool>. Maybe there's a way to implicitly 
            // cast a delegate to a Func?
            return (x, y) =>
             {
                 foreach (var predicate in predicates)
                 {
                     if (!predicate(x, y))
                     {
                         return false;
                     }
                 }

                 return true;
             };
        }

        /// <summary>
        /// Takes a list of three-arity predicates and returns a function which tests if a given object 
        /// satisifies each predicate.
        /// </summary>
        /// <typeparam name="T1">The type of the first predicate parameter.</typeparam>
        /// <typeparam name="T2">The type of the second predicate parameter.</typeparam>
        /// <typeparam name="T3">The type of the third predicate parameter.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T1, T2, T3, bool> AllPass<T1, T2, T3>(
            this Func<T1, T2, T3, bool>[] predicates)
        {
            return (x, y, z) =>
            {
                foreach (var predicate in predicates)
                {
                    if (!predicate(x, y, z))
                    {
                        return false;
                    }
                }

                return true;
            };
        }

        /// <summary>
        /// Takes a list of four-arity predicates and returns a function which tests if a given object 
        /// satisifies each predicate.
        /// </summary>
        /// <typeparam name="T1">The type of the first predicate parameter.</typeparam>
        /// <typeparam name="T2">The type of the second predicate parameter.</typeparam>
        /// <typeparam name="T3">The type of the third predicate parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth predicate parameter.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T1, T2, T3, T4, bool> AllPass<T1, T2, T3, T4>(
            this Func<T1, T2, T3, T4, bool>[] predicates)
        {
            return (w, x, y, z) =>
            {
                foreach (var predicate in predicates)
                {
                    if (!predicate(w, x, y, z))
                    {
                        return false;
                    }
                }

                return true;
            };
        }

        /// <summary>
        /// Takes a list of predicates and returns a function which tests if each item of a list 
        /// satisifies each predicate.
        /// </summary>
        /// <typeparam name="T">The type the predicates test.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T[], bool> AllPassVariadic<T>(this Func<T, bool>[] predicates)
        {
            return list =>
            {
                foreach (var item in list)
                {
                    foreach (var predicate in predicates)
                    {
                        if (!predicate(item))
                        {
                            return false;
                        }
                    }
                }

                return true;
            };
        }

        /// <summary>
        /// Takes a list of 2-arity predicates and returns a curried version of a function that
        /// tests all the predicates.
        /// </summary>
        /// <typeparam name="T1">The type of the first predicate parameter.</typeparam>
        /// <typeparam name="T2">The type of the second predicate parameter.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T1, Func<T2, bool>> AllPassCurried<T1, T2>(
            this Func<T1, T2, bool>[] predicates)
        {
            return Curry(AllPass(predicates));
        }

        /// <summary>
        /// Takes a list of 2-arity predicates and returns a curried version of a function that
        /// tests all the predicates.
        /// </summary>
        /// <typeparam name="T1">The type of the first predicate parameter.</typeparam>
        /// <typeparam name="T2">The type of the second predicate parameter.</typeparam>
        /// <typeparam name="T3">The type of the third predicate parameter.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T1, Func<T2, Func<T3, bool>>> AllPassCurried<T1, T2, T3>(
            this Func<T1, T2, T3, bool>[] predicates)
        {
            return Curry(AllPass(predicates));
        }

        /// <summary>
        /// Takes a list of 2-arity predicates and returns a curried version of a function that
        /// tests all the predicates.
        /// </summary>
        /// <typeparam name="T1">The type of the first predicate parameter.</typeparam>
        /// <typeparam name="T2">The type of the second predicate parameter.</typeparam>
        /// <typeparam name="T3">The type of the third predicate parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth predicate parameter.</typeparam>
        /// <param name="predicates">The list of predicates.</param>
        public static Func<T1, Func<T2, Func<T3, Func<T4, bool>>>> AllPassCurried<T1, T2, T3, T4>(
            this Func<T1, T2, T3, T4, bool>[] predicates)
        {
            return Curry(AllPass(predicates));
        }
    }
}
