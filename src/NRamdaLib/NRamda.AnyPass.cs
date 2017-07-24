using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
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

        public static Func<T1, Func<T2, bool>> AnyPassCurried<T1, T2>(
            this Func<T1, T2, bool>[] predicates)
        {
            return Curry(AnyPass(predicates));
        }

        public static Func<T1, Func<T2, Func<T3, bool>>> AnyPassCurried<T1, T2, T3>(
            this Func<T1, T2, T3, bool>[] predicates)
        {
            return Curry(AnyPass(predicates));
        }

        public static Func<T1, Func<T2, Func<T3, Func<T4, bool>>>> AnyPassCurried<T1, T2, T3, T4>(
            this Func<T1, T2, T3, T4, bool>[] predicates)
        {
            return Curry(AnyPass(predicates));
        }
    }
}
