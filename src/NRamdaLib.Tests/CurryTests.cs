using System;
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

            var curriedAdd = NRamda.Curry(add);

            curriedAdd(3)(4).Should().Be(add(3, 4));
        }

        [Fact]
        public void CanCurryTwoParameterStringFunction()
        {
            Func<string, string, string> append = (x, y) => x + y;

            var curriedAppend = NRamda.Curry(append);

            curriedAppend("hello")("there").Should().Be(append("hello", "there"));
        }
    }
}
