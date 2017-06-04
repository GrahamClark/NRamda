using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class AdjustTests
    {
        [Fact]
        public void CanAddToSpecificIndex()
        {
            var expected = new[] {1, 12, 3};

            var adjusted = NRamda.Adjust(NRamda.Add(10), 1, new[] {1, 2, 3});

            adjusted.ShouldAllBeEquivalentTo(expected);
        }

        [Fact]
        public void OffsetsNegativeIndexesFromTheEndOfTheArray()
        {
            var expected = new[] {0, 2, 2, 3};

            var adjusted = NRamda.Adjust(NRamda.Add(1), -3, new[] {0, 1, 2, 3});

            adjusted.ShouldAllBeEquivalentTo(expected);
        }

        [Fact]
        public void DoesNotMutateOriginalArray()
        {
            var list = new[] {0, 1, 2, 3};

            var adjusted = NRamda.Adjust(NRamda.Add(1), 2, list);

            adjusted.ShouldAllBeEquivalentTo(new[] {0, 1, 3, 3});
            list.ShouldAllBeEquivalentTo(new[] {0, 1, 2, 3});
        }

        [Fact]
        public void CurriesTheArguments()
        {
            var adjusted = NRamda.Adjust(NRamda.Add(1))(2)(new[] {0, 1, 2, 3});

            adjusted.ShouldAllBeEquivalentTo(new[] {0, 1, 3, 3});
        }
    }
}
