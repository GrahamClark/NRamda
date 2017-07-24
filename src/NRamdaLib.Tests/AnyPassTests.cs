using System;

using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class AnyPassTests
    {
        private readonly Func<int, bool> _odd = x => x % 2 != 0;
        private readonly Func<int, bool> _gt20 = x => x > 20;
        private readonly Func<int, bool> _lt5 = x => x < 5;
        private readonly Func<int, int, bool> _sumLt100 = (x, y) => x + y < 100;
        private readonly Func<int, int, bool> _bothDivisibleBy5 =
            (x, y) => x % 5 == 0 && y % 5 == 0;

        [Fact]
        public void ReportsWhetherAnyPredicatesAreSatisfiedByAGivenValue()
        {
            var ok = new[] { _odd, _gt20, _lt5 }.AnyPass();

            ok(7).Should().BeTrue();
            ok(9).Should().BeTrue();
            ok(10).Should().BeFalse();
            ok(18).Should().BeFalse();
            ok(3).Should().BeTrue();
            ok(22).Should().BeTrue();
        }

        [Fact]
        public void ReturnsFalseForEmptyPredicateList()
        {
            NRamda.AnyPass(new Func<int, bool>[0])(3).Should().BeFalse();
        }

        [Fact]
        public void CurriedWith2ParamPredicates()
        {
            var ok = new[] { _sumLt100, _bothDivisibleBy5 }.AnyPassCurried();

            ok(90)(9).Should().BeTrue();
            ok(95)(25).Should().BeTrue();
            ok(5)(30).Should().BeTrue();
        }
    }
}
