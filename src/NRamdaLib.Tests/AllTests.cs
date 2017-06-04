using System;

using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class AllTests
    {
        private readonly Func<int, bool> _isEven = x => x % 2 == 0;
        private readonly Func<bool, bool> _isFalse = x => x == false;
        private readonly Func<int, bool> _t = x => true;

        [Fact]
        public void ReturnsTrueIfAllElementsSatisfyThePredicate()
        {
            NRamda.All(_isEven, new[] {2, 4, 6, 8, 10, 12}).Should().BeTrue();

            _isFalse.All(new[] {false, false, false}).Should().BeTrue();
        }

        [Fact]
        public void ReturnsFalseIfAnyElementFailsToSaitsfyThePredicate()
        {
            NRamda.All(_isEven, new[] {2, 4, 6, 8, 9, 10}).Should().BeFalse();
        }

        [Fact]
        public void ReturnsTrueForAnEmptyList()
        {
            NRamda.All(_t, new int[0]).Should().BeTrue();
        }

        [Fact]
        public void WorksWithMoreComplexObjects()
        {
            var cs = new[] {new C {X = "abc"}, new C {X = "ade"}, new C {X = "fghajk"}};
            Func<C, bool> length3 = c => c.X.Length == 3;
            Func<C, bool> hasA = c => c.X.Contains("a");

            NRamda.All(length3, cs).Should().BeFalse();
            NRamda.All(hasA, cs).Should().BeTrue();
        }

        [Fact]
        public void IsCurried()
        {
            NRamda.All(_isEven)(new[] {2, 4, 6, 8, 10}).Should().BeTrue();
        }

        private class C
        {
            public string X { get; set; }
        }
    }
}
