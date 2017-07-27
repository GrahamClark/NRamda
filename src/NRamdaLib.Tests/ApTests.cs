using System;

using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class ApTests
    {
        private readonly Func<int, int> _mult2 = x => x * 2;
        private readonly Func<int, int> _plus3 = x => x + 3;

        [Fact]
        public void CanApplyFunctionsToList()
        {
            NRamda.Ap(new[] { _mult2, _plus3 }, new[] { 1, 2, 3 })
                .ShouldAllBeEquivalentTo(new[] { 2, 4, 6, 4, 5, 6 });
        }

        [Fact]
        public void CanApplyStringFunctions()
        {
            var applied = NRamda.Ap(
                new[] { NRamda.Concat("tasty "), NRamda.ToUpper },
                new[] { "pizza", "salad" });

            applied.ShouldBeEquivalentTo(
                new[] { "tasty pizza", "tasty salad", "PIZZA", "SALAD" });
        }

        [Fact]
        public void CanApplyIntFunctions()
        {
            NRamda.Ap(
                      new[] { NRamda.Multiply(2), NRamda.Add(3) },
                      new[] { 1, 2, 3 })
                  .ShouldBeEquivalentTo(new[] { 2, 4, 6, 4, 5, 6 });
        }

        [Fact]
        public void IsCurried()
        {
            var applied = NRamda.Ap(new[] { _mult2, _plus3 });
            applied(new[] { 1, 2, 3 }).ShouldBeEquivalentTo(new[] { 2, 4, 6, 4, 5, 6 });
        }
    }
}
