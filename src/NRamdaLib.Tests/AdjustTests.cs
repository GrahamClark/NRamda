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
    }
}
