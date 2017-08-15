using System;
using System.Collections.Generic;

using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class ComposeTests
    {
        [Fact]
        public void CanComposeSomeIntFunctions()
        {
            NRamda.Compose(Math.Abs, NRamda.Add(1), NRamda.Multiply(2))(-4).Should().Be(7);
        }

        [Fact]
        public void CanComposeDifferentArityFunctions()
        {
            Func<string, string, string> classyGreeting =
                (first, last) => $"The name's {last}, {first} {last}";

            var yellGreeting = NRamda.Compose(NRamda.ToUpper, classyGreeting);

            yellGreeting("James", "Bond").Should().Be("THE NAME'S BOND, JAMES BOND");
        }

        [Fact]
        public void CanComposeFunctionsWithDifferentTypes()
        {
            var f = NRamda
                .Compose<string, int, Func<int, int>, Func<IEnumerable<int>, IEnumerable<int>>>(
                    NRamda.Map,
                    NRamda.Multiply,
                    int.Parse);

            f("10")(new[] { 1, 2, 3 }).ShouldBeEquivalentTo(new[] { 10, 20, 30 });
        }
    }
}
