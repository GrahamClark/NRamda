using System;
using FluentAssertions;
using Xunit;

namespace NRamdaLib.Tests
{
    public class MapTests
    {
        [Fact]
        public void CanMapOverEnumerable()
        {
            Func<int, int> timesTwo = x => x * 2;
            var expected = new[] {2, 4, 6};

            var doubleList = timesTwo.Map(new[] {1, 2, 3});

            doubleList.ShouldAllBeEquivalentTo(expected);
        }
    }
}
