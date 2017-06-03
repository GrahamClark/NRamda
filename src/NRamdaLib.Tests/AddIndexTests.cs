using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace NRamdaLib.Tests
{
    public class AddIndexTests
    {
        [Fact]
        public void CanWorkLikeNormalMap()
        {
            Func<int, int, IEnumerable<int>, int> timesTwo = (x, idx, list) => x * 2;
            var mapIndexed = NRamda.AddIndex<int>(NRamda.Map);
            var expected = new[] {2, 4, 6, 8};

            var mapped = mapIndexed(timesTwo, new[] {1, 2, 3, 4});

            mapped.ShouldAllBeEquivalentTo(expected);
        }

        [Fact]
        public void CanUseIndexParameter()
        {
            var mapIndexed = NRamda.AddIndex<string>(NRamda.Map);
            var expected = new[] {"0-f", "1-o", "2-o", "3-b", "4-a", "5-r"};

            var mapped = mapIndexed(
                (val, idx, list) => $"{idx}-{val}",
                new[] {"f", "o", "o", "b", "a", "r"});

            mapped.ShouldAllBeEquivalentTo(expected);
        }

        [Fact]
        public void CanUseEntireListParameter()
        {
            Func<int, int, IEnumerable<int>, int> squareEnds = 
                (x, idx, list) => idx == 0 || idx == list.Count() - 1 ? x * x : x;
            var mapIndexed = NRamda.AddIndex<int>(NRamda.Map);
            var expected = new[] {64, 6, 7, 5, 3, 0, 81};

            var mapped = mapIndexed(squareEnds, new[] {8, 6, 7, 5, 3, 0, 9});

            mapped.ShouldAllBeEquivalentTo(expected);
        }
    }
}
