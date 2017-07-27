using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static int Multiply(int x, int y)
        {
            return x * y;
        }

        public static Func<int, int> Multiply(this int x)
        {
            return Curry<int, int, int>(Multiply)(x);
        }

        public static float Multiply(float x, float y)
        {
            return x * y;
        }

        public static Func<float, float> Multiply(this float x)
        {
            return Curry<float, float, float>(Multiply)(x);
        }

        public static double Multiply(double x, double y)
        {
            return x * y;
        }

        public static Func<double, double> Multiply(this double x)
        {
            return Curry<double, double, double>(Multiply)(x);
        }

        public static decimal Multiply(decimal x, decimal y)
        {
            return x * y;
        }

        public static Func<decimal, decimal> Multiply(this decimal x)
        {
            return Curry<decimal, decimal, decimal>(Multiply)(x);
        }
    }
}
