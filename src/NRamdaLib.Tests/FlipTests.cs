using System;
using System.Collections.Generic;

using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class FlipTests
    {
        [Fact]
        public void CanFlipAFunction()
        {
            Func<int, int, int, IEnumerable<int>> mergeThree = (x, y, z) =>
                new int[] { }.Concat(new[] { x, y, z });

            mergeThree(1, 2, 3).ShouldBeEquivalentTo(new[] { 1, 2, 3 });

            mergeThree.Flip()(1, 2, 3).ShouldBeEquivalentTo(new[] { 2, 1, 3 });
        }

        [Fact]
        public void ReturnsACurriedFunction()
        {
            Func<string, string, string, string> f = (a, b, c) => a + " " + b + " " + c;
            var g = f.FlipCurried()("a");

            g("b")("c").Should().Be("b a c");
        }
    }
}
