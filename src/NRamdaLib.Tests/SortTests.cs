using System;

using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class SortTests
    {
        [Fact]
        public void CanSortInts()
        {
            var list = new[] { 3, 8, 5, 1, 7 };
            Func<int, int, int> comparator = (x, y) => x - y;

            var sorted = comparator.Sort(list);

            sorted.ShouldBeEquivalentTo(new[] { 1, 3, 5, 7, 8 });
            list.ShouldBeEquivalentTo(new[] { 3, 8, 5, 1, 7 });
        }

        [Fact]
        public void IsCurried()
        {
            var sortByLength = NRamda.Sort((string x, string y) => x.Length - y.Length);

            sortByLength(new[] { "one", "two", "three", "four", "five", "six" })
                .ShouldBeEquivalentTo(new[] { "one", "two", "six", "four", "five", "three" });
        }
    }
}
