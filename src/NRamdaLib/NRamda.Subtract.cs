using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Subtracts two integers.
        /// </summary>
        /// <param name="x">The first integer to subtract.</param>
        /// <param name="y">The second integer to subtract.</param>
        public static int Subtract(int x, int y)
        {
            return x - y;
        }

        /// <summary>
        /// Takes an integer and creates a function that subtracts this integer to another.
        /// </summary>
        /// <param name="x">The integer to subtract to another.</param>
        public static Func<int, int> Subtract(this int x)
        {
            return Curry<int, int, int>(Subtract)(x);
        }

        /// <summary>
        /// Subtracts two floats.
        /// </summary>
        /// <param name="x">The first float to subtract.</param>
        /// <param name="y">The second float to subtract.</param>
        public static float Subtract(float x, float y)
        {
            return x - y;
        }

        /// <summary>
        /// Takes an float and creates a function that subtracts this float to another.
        /// </summary>
        /// <param name="x">The float to subtract to another.</param>
        public static Func<float, float> Subtract(this float x)
        {
            return Curry<float, float, float>(Subtract)(x);
        }

        /// <summary>
        /// Subtracts two doubles.
        /// </summary>
        /// <param name="x">The first double to subtract.</param>
        /// <param name="y">The second double to subtract.</param>
        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        /// <summary>
        /// Takes an double and creates a function that subtracts this double to another.
        /// </summary>
        /// <param name="x">The double to subtract to another.</param>
        public static Func<double, double> Subtract(this double x)
        {
            return Curry<double, double, double>(Subtract)(x);
        }

        /// <summary>
        /// Subtracts two decimals.
        /// </summary>
        /// <param name="x">The first decimal to subtract.</param>
        /// <param name="y">The second decimal to subtract.</param>
        public static decimal Subtract(decimal x, decimal y)
        {
            return x - y;
        }

        /// <summary>
        /// Takes an decimal and creates a function that subtracts this decimal to another.
        /// </summary>
        /// <param name="x">The decimal to subtract to another.</param>
        public static Func<decimal, decimal> Subtract(this decimal x)
        {
            return Curry<decimal, decimal, decimal>(Subtract)(x);
        }
    }
}
