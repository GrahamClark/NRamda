﻿using System;

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
            return Curry<int, int, int>(Add)(x);
        }

        public static float Add(float x, float y)
        {
            return x + y;
        }

        public static Func<float, float> Add(float x)
        {
            return Curry<float, float, float>(Add)(x);
        }

        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static Func<double, double> Add(double x)
        {
            return Curry<double, double, double>(Add)(x);
        }

        public static decimal Add(decimal x, decimal y)
        {
            return x + y;
        }

        public static Func<decimal, decimal> Add(decimal x)
        {
            return Curry<decimal, decimal, decimal>(Add)(x);
        }
    }
}
