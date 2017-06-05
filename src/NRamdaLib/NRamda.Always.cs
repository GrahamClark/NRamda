using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static Func<T1> Always<T1>(T1 value)
        {
            return () => value;
        }

        public static Func<T1, T2> Always<T1, T2>(T2 value)
        {
            return x => value;
        }

        public static Func<T1, Func<T2, T3>> Always<T1, T2, T3>(T3 value)
        {
            return Curry<T1, T2, T3>((x, y) => value);
        }
    }
}
