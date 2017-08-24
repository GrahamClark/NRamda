namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static T Identity<T>(T t)
        {
            return t;
        }

        public static T Identity<T>(params T[] ts)
        {
            return ts[0];
        }
    }
}
