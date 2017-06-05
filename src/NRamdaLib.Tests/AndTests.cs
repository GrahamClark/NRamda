using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class AndTests
    {
        [Fact]
        public void ComparesTwoValuesWithLogicalAnd()
        {
            NRamda.And(true, true).Should().BeTrue();
            NRamda.And(true, false).Should().BeFalse();
            NRamda.And(false, true).Should().BeFalse();
            NRamda.And(false, false).Should().BeFalse();
        }

        [Fact]
        public void AndIsCurried()
        {
            var halfTruth = NRamda.And(true);

            halfTruth(false).Should().BeFalse();
            halfTruth(true).Should().BeTrue();
        }
    }
}
