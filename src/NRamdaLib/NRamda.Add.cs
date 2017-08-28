using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Adds two integers.
        /// </summary>
        /// <param name="x">The first integer to add.</param>
        /// <param name="y">The second integer to add.</param>
        public static int Add(this int x, int y)
        {
            return x + y;
        }

        /// <summary>
        /// Takes an integer and creates a function that adds this integer to another.
        /// </summary>
        /// <param name="x">The integer to add to another.</param>
        public static Func<int, int> Add(this int x)
        {
            return Curry<int, int, int>(Add)(x);
        }

        /// <summary>
        /// Adds two floats.
        /// </summary>
        /// <param name="x">The first float to add.</param>
        /// <param name="y">The second float to add.</param>
        public static float Add(this float x, float y)
        {
            return x + y;
        }

        /// <summary>
        /// Takes an float and creates a function that adds this float to another.
        /// </summary>
        /// <param name="x">The float to add to another.</param>
        public static Func<float, float> Add(this float x)
        {
            return Curry<float, float, float>(Add)(x);
        }

        /// <summary>
        /// Adds two doubles.
        /// </summary>
        /// <param name="x">The first double to add.</param>
        /// <param name="y">The second double to add.</param>
        public static double Add(this double x, double y)
        {
            return x + y;
        }

        /// <summary>
        /// Takes an double and creates a function that adds this double to another.
        /// </summary>
        /// <param name="x">The double to add to another.</param>
        public static Func<double, double> Add(this double x)
        {
            return Curry<double, double, double>(Add)(x);
        }

        /// <summary>
        /// Adds two decimals.
        /// </summary>
        /// <param name="x">The first decimal to add.</param>
        /// <param name="y">The second decimal to add.</param>
        public static decimal Add(this decimal x, decimal y)
        {
            return x + y;
        }

        /// <summary>
        /// Takes an decimal and creates a function that adds this decimal to another.
        /// </summary>
        /// <param name="x">The decimal to add to another.</param>
        public static Func<decimal, decimal> Add(this decimal x)
        {
            return Curry<decimal, decimal, decimal>(Add)(x);
        }
    }
}
