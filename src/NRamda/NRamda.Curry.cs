using System;

namespace NRamda
{
    public static partial class NRamda
    {
        public static Func<T1, Func<T2, T3>> Curry<T1, T2, T3>(Func<T1, T2, T3> func)
        {
            return x => y => func(x, y);
        }
    }
}
