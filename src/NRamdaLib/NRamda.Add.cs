using System;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static Func<int, int> Add(int x)
        {
            return y => x + y;
        }

        public static float Add(float x, float y)
        {
            return x + y;
        }

        public static Func<float, float> Add(float x)
        {
            return y => x + y;
        }

        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static Func<double, double> Add(double x)
        {
            return y => x + y;
        }

        public static decimal Add(decimal x, decimal y)
        {
            return x + y;
        }

        public static Func<decimal, decimal> Add(decimal x)
        {
            return y => x + y;
        }
    }
}
