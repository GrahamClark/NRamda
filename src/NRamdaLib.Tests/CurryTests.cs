using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

namespace NRamdaLib.Tests
{
    public class CurryTests
    {
        [Fact]
        public void CanCurryTwoParameterIntFunction()
        {
            Func<int, int, int> add = (x, y) => x + y;

            var curriedAdd = add.Curry();

            curriedAdd(3)(4).Should().Be(add(3, 4));
        }

        [Fact]
        public void CanCurryTwoParameterStringFunction()
        {
            Func<string, string, string> append = (x, y) => x + y;

            var curriedAppend = append.Curry();

            curriedAppend("hello")("there").Should().Be(append("hello", "there"));
        }

        [Fact]
        public void CanCurryThreeParameterMixedTypeFunction()
        {
            Func<int, string, int, string> addString = (x, op, y) => $"{x} {op} {y}";

            var curriedAddString = addString.Curry();

            curriedAddString(1)("+")(2).Should().Be(addString(1, "+", 2));
        }

        [Fact]
        public void CanCurryFourParameterFunction()
        {
            Func<double, double, int, int, string> f =
                (w, x, y, z) => (w % x + y - z).ToString(CultureInfo.InvariantCulture);

            var curriedF = f.Curry();

            curriedF(3.5)(2.6)(7)(9).Should().Be(f(3.5, 2.6, 7, 9));
        }
    }
}
