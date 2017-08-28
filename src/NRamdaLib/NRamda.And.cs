using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Returns true if both arguments are true; false otherwise.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static bool And(bool x, bool y)
        {
            return x && y;
        }

        /// <summary>
        /// Takes a parameter and returns a function that ands its parameter and the 
        /// original parameter.   
        /// </summary>
        /// <param name="x">The first operand.</param>
        public static Func<bool, bool> And(bool x)
        {
            return Curry<bool, bool, bool>(And)(x);
        }
    }
}
