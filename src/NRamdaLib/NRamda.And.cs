using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static bool And(bool x, bool y)
        {
            return x && y;
        }

        public static Func<bool, bool> And(bool x)
        {
            return Curry<bool, bool, bool>(And)(x);
        }
    }
}
