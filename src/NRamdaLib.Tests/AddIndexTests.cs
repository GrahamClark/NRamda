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
            var mapIndexed = NRamda.AddIndex<int>(NRamda.Map);
            int TimesTwo(int x, int idx, IEnumerable<int> list) => x * 2;
            var expected = new[] {2, 4, 6, 8};

            var mapped = mapIndexed(TimesTwo, new[] {1, 2, 3, 4});

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
            var mapIndexed = NRamda.AddIndex<int>(NRamda.Map);

            int SquareEnds(int x, int idx, IEnumerable<int> list) =>
                idx == 0 || idx == list.Count() - 1 ? x * x : x;

            var expected = new[] {64, 6, 7, 5, 3, 0, 81};

            var mapped = mapIndexed(SquareEnds, new[] {8, 6, 7, 5, 3, 0, 9});

            mapped.ShouldAllBeEquivalentTo(expected);
        }

        [Fact]
        public void CanWorkWithBinaryFunctions()
        {
            var reduceIndexed = NRamda.AddIndex<int, int>(NRamda.Reduce);

            int TimesIndexed(
                int total,
                int number,
                int index,
                IEnumerable<int> list) => total + number * index;

            int expected = 40;

            var actual = reduceIndexed(TimesIndexed, 0, new[] {1, 2, 3, 4, 5});

            actual.Should().Be(expected);
        }
    }
}
