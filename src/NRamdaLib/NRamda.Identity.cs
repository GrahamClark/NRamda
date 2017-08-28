namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Returns the supplied value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="t">The value.</param>
        public static T Identity<T>(T t)
        {
            return t;
        }

        /// <summary>
        /// Returns the first item of the parameter array supplied.
        /// </summary>
        /// <typeparam name="T">The type of the parameters.</typeparam>
        /// <param name="ts">The parameter array.</param>
        public static T Identity<T>(params T[] ts)
        {
            return ts[0];
        }
    }
}
