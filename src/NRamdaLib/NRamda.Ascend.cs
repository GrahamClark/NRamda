using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static Comparison<T> Ascend<T>(Func<T, T, int> func)
        {
            return (x, y) => func(x, y);
        }

        public static Comparison<T> Ascend<T>(Func<T, int> func)
        {
            return (x, y) => func(x);
        }
    }
}
