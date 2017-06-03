using System;

namespace NRamdaLib
{
    public static class NRamda
    {
        public static Func<T1, Func<T2, T3>> Curry<T1, T2, T3>(this Func<T1, T2, T3> func)
        {
            return x => y => func(x, y);
        }

        public static Func<T1, Func<T2, Func<T3, T4>>> Curry<T1, T2, T3, T4>(
            this Func<T1, T2, T3, T4> func)
        {
            return x => y => z => func(x, y, z);
        }

        public static Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> Curry<T1, T2, T3, T4, T5>(
            this Func<T1, T2, T3, T4, T5> func)
        {
            return w => x => y => z => func(w, x, y, z);
        }
    }
}
