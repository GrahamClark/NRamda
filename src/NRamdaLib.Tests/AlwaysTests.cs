using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class AlwaysTests
    {
        [Fact]
        public void AlwaysReturnsGivenValue()
        {
            var t = NRamda.Always("Tee");

            t().Should().Be("Tee");
            t().Should().Be("Tee");
        }

        [Fact]
        public void AlwaysWithOneParameter()
        {
            var t = NRamda.Always<int, string>("Tee");

            t(1).Should().Be("Tee");
            t(456).Should().Be("Tee");
        }

        [Fact]
        public void AlwaysWithTwoParametersIsCurried()
        {
            var t = NRamda.Always<int, bool, string>("Tee");

            t(3)(true).Should().Be("Tee");
            t(3939)(false).Should().Be("Tee");
        }
    }
}
