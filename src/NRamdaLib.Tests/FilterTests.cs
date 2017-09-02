using System;
using System.Collections.Generic;

using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class FilterTests
    {
        private Func<int, bool> _isEven = x => x % 2 == 0;

        [Fact]
        public void CanFilterAnArray()
        {
            _isEven.Filter(new[] { 1, 2, 3, 4 }).ShouldBeEquivalentTo(new[] { 2, 4 });
        }

        [Fact]
        public void CanFilterADictionary()
        {
            var d = new Dictionary<string, int> { ["a"] = 1, ["b"] = 2, ["c"] = 3, ["d"] = 4 };
            _isEven.Filter(d)
                   .ShouldBeEquivalentTo(new Dictionary<string, int> { ["b"] = 2, ["d"] = 4 });
        }

        [Fact]
        public void ReturnsAnEmptyArrayIfNoElementMatches()
        {
            NRamda.Filter(x => x > 100, new[] { 1, 9, 99 }).ShouldBeEquivalentTo(new int[0]);
        }

        [Fact]
        public void ReturnsAnEmptyArrayIfAskedToFilterAnEmptyArray()
        {
            NRamda.Filter(x => x > 100, new int[0]).ShouldBeEquivalentTo(new int[0]);
        }

        [Fact]
        public void IsCurried()
        {
            var filterer = _isEven.Filter();
            filterer(new[] { 6, 10, 11, 13, 14 }).ShouldBeEquivalentTo(new[] { 6, 10, 14 });
        }
    }
}
