using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
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

        // Really difficult to take an array of arbitrary-arity predicates.
        // A custom delegate can be defined, but then everything needs to be
        // defined in terms of this instead of being able to use implicit 
        // "casting" to Func<..., bool>. Maybe there's a way to implicitly 
        // cast a delegate to a Func?
        public static Func<T1, T2, bool> AllPass<T1, T2>(this Func<T1, T2, bool>[] predicates)
        {
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

        public static Func<T1, Func<T2, bool>> AllPassCurried<T1, T2>(
            this Func<T1, T2, bool>[] predicates)
        {
            return Curry(AllPass(predicates));
        }

        public static Func<T1, Func<T2, Func<T3, bool>>> AllPassCurried<T1, T2, T3>(
            this Func<T1, T2, T3, bool>[] predicates)
        {
            return Curry(AllPass(predicates));
        }

        public static Func<T1, Func<T2, Func<T3, Func<T4, bool>>>> AllPassCurried<T1, T2, T3, T4>(
            this Func<T1, T2, T3, T4, bool>[] predicates)
        {
            return Curry(AllPass(predicates));
        }
    }
}
