using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static int Subtract(int x, int y)
        {
            return x - y;
        }

        public static Func<int, int> Subtract(this int x)
        {
            return Curry<int, int, int>(Subtract)(x);
        }

        public static float Subtract(float x, float y)
        {
            return x - y;
        }

        public static Func<float, float> Subtract(this float x)
        {
            return Curry<float, float, float>(Subtract)(x);
        }

        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        public static Func<double, double> Subtract(this double x)
        {
            return Curry<double, double, double>(Subtract)(x);
        }

        public static decimal Subtract(decimal x, decimal y)
        {
            return x - y;
        }

        public static Func<decimal, decimal> Subtract(this decimal x)
        {
            return Curry<decimal, decimal, decimal>(Subtract)(x);
        }
    }
}
