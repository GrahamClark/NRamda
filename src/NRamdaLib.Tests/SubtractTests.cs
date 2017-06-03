using FluentAssertions;
using Xunit;

namespace NRamdaLib.Tests
{
    public class SubtractTests
    {
        [Fact]
        public void CanSubtractTwoInts()
        {
            NRamda.Subtract(2, 5).Should().Be(2 - 5);
        }

        [Fact]
        public void CanSubtractTwoFloats()
        {
            NRamda.Subtract(243.342f, 3.345f).Should().Be(243.342f - 3.345f);
        }

        [Fact]
        public void CanSubtractTwoDoubles()
        {
            NRamda.Subtract(243.342d, 3.345d).Should().Be(243.342d - 3.345d);
        }

        [Fact]
        public void CanSubtractTwoDecimals()
        {
            NRamda.Subtract(50.45m, 243.42m).Should().Be(50.45m - 243.42m);
        }

        [Fact]
        public void CanSubtractTwoIntsWithPartialApplication()
        {
            NRamda.Subtract(2)(5).Should().Be(2 - 5);
        }

        [Fact]
        public void CanSubtractTwoFloatsWithPartialApplication()
        {
            NRamda.Subtract(243.342f)(3.345f).Should().Be(243.342f - 3.345f);
        }

        [Fact]
        public void CanSubtractTwoDoublesWithPartialApplication()
        {
            NRamda.Subtract(3.345d)(243.342d).Should().Be(3.345d - 243.342d);
        }

        [Fact]
        public void CanSubtractTwoDecimalsWithPartialApplication()
        {
            NRamda.Subtract(50.45m)(243.42m).Should().Be(50.45m - 243.42m);
        }
    }
}
