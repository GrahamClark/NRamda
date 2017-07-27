using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class MultiplyTests
    {
        [Fact]
        public void CanMultiplyTwoInts()
        {
            NRamda.Multiply(2, 5).Should().Be(2 * 5);
        }

        [Fact]
        public void CanMultiplyTwoFloats()
        {
            NRamda.Multiply(3.345f, 243.342f).Should().Be(3.345f * 243.342f);
        }

        [Fact]
        public void CanMultiplyTwoDoubles()
        {
            NRamda.Multiply(3.345d, 243.342d).Should().Be(3.345d * 243.342d);
        }

        [Fact]
        public void CanMultiplyTwoDecimals()
        {
            NRamda.Multiply(50.45m, 243.42m).Should().Be(50.45m * 243.42m);
        }

        [Fact]
        public void CanMultiplyTwoIntsWithPartialApplication()
        {
            NRamda.Multiply(2)(5).Should().Be(2 * 5);
        }

        [Fact]
        public void CanMultiplyTwoFloatsWithPartialApplication()
        {
            NRamda.Multiply(3.345f)(243.342f).Should().Be(3.345f * 243.342f);
        }

        [Fact]
        public void CanMultiplyTwoDoublesWithPartialApplication()
        {
            NRamda.Multiply(3.345d)(243.342d).Should().Be(3.345d * 243.342d);
        }

        [Fact]
        public void CanMultiplyTwoDecimalsWithPartialApplication()
        {
            NRamda.Multiply(50.45m)(243.42m).Should().Be(50.45m * 243.42m);
        }
    }
}
