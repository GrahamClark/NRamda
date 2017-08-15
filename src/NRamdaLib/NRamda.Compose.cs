using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static Func<T1, T3> Compose<T1, T2, T3>(Func<T2, T3> first, Func<T1, T2> second)
        {
            return x => first(second(x));
        }

        public static Func<T1, T2, T4> Compose<T1, T2, T3, T4>(
            Func<T3, T4> first,
            Func<T1, T2, T3> second)
        {
            return (x, y) => first(second(x, y));
        }

        public static Func<T1, T2, T3, T5> Compose<T1, T2, T3, T4, T5>(
            Func<T4, T5> first,
            Func<T1, T2, T3, T4> second)
        {
            return (x, y, z) => first(second(x, y, z));
        }

        public static Func<T1, T4> Compose<T1, T2, T3, T4>(
            Func<T3, T4> first,
            Func<T2, T3> second,
            Func<T1, T2> third)
        {
            return x => first(second(third(x)));
        }

        public static Func<T1, T2, T5> Compose<T1, T2, T3, T4, T5>(
            Func<T4, T5> first,
            Func<T3, T4> second,
            Func<T1, T2, T3> third)
        {
            return (x, y) => first(second(third(x, y)));
        }

        public static Func<T1, T2, T3, T6> Compose<T1, T2, T3, T4, T5, T6>(
            Func<T5, T6> first,
            Func<T4, T5> second,
            Func<T1, T2, T3, T4> third)
        {
            return (x, y, z) => first(second(third(x, y, z)));
        }

        public static Func<T1, T5> Compose<T1, T2, T3, T4, T5>(
            Func<T4, T5> first,
            Func<T3, T4> second,
            Func<T2, T3> third,
            Func<T1, T2> fourth)
        {
            return x => first(second(third(fourth(x))));
        }

        public static Func<T1, T2, T6> Compose<T1, T2, T3, T4, T5, T6>(
            Func<T5, T6> first,
            Func<T4, T5> second,
            Func<T3, T4> third,
            Func<T1, T2, T3> fourth)
        {
            return (x, y) => first(second(third(fourth(x, y))));
        }

        public static Func<T1, T2, T3, T7> Compose<T1, T2, T3, T4, T5, T6, T7>(
            Func<T6, T7> first,
            Func<T5, T6> second,
            Func<T4, T5> third,
            Func<T1, T2, T3, T4> fourth)
        {
            return (x, y, z) => first(second(third(fourth(x, y, z))));
        }
    }
}
