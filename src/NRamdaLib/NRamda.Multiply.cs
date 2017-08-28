using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Multiplies two integers.
        /// </summary>
        /// <param name="x">The first integer to multiply.</param>
        /// <param name="y">The second integer to multiply.</param>
        public static int Multiply(int x, int y)
        {
            return x * y;
        }

        /// <summary>
        /// Takes an integer and creates a function that multiplies this integer to another.
        /// </summary>
        /// <param name="x">The integer to multiply to another.</param>
        public static Func<int, int> Multiply(this int x)
        {
            return Curry<int, int, int>(Multiply)(x);
        }

        /// <summary>
        /// Multiplies two floats.
        /// </summary>
        /// <param name="x">The first float to multiply.</param>
        /// <param name="y">The second float to multiply.</param>
        public static float Multiply(float x, float y)
        {
            return x * y;
        }

        /// <summary>
        /// Takes an float and creates a function that multiplies this float to another.
        /// </summary>
        /// <param name="x">The float to multiply to another.</param>
        public static Func<float, float> Multiply(this float x)
        {
            return Curry<float, float, float>(Multiply)(x);
        }

        /// <summary>
        /// Multiplies two doubles.
        /// </summary>
        /// <param name="x">The first double to multiply.</param>
        /// <param name="y">The second double to multiply.</param>
        public static double Multiply(double x, double y)
        {
            return x * y;
        }

        /// <summary>
        /// Takes an double and creates a function that multiplies this double to another.
        /// </summary>
        /// <param name="x">The double to multiply to another.</param>
        public static Func<double, double> Multiply(this double x)
        {
            return Curry<double, double, double>(Multiply)(x);
        }

        /// <summary>
        /// Multiplies two decimals.
        /// </summary>
        /// <param name="x">The first decimal to multiply.</param>
        /// <param name="y">The second decimal to multiply.</param>
        public static decimal Multiply(decimal x, decimal y)
        {
            return x * y;
        }

        /// <summary>
        /// Takes an decimal and creates a function that multiplies this decimal to another.
        /// </summary>
        /// <param name="x">The decimal to multiply to another.</param>
        public static Func<decimal, decimal> Multiply(this decimal x)
        {
            return Curry<decimal, decimal, decimal>(Multiply)(x);
        }
    }
}
