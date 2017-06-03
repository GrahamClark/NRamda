using FluentAssertions;
using Xunit;

namespace NRamdaLib.Tests
{
    public class AddTests
    {
        [Fact]
        public void CanAddTwoInts()
        {
            NRamda.Add(2, 5).Should().Be(2 + 5);
        }

        [Fact]
        public void CanAddTwoFloats()
        {
            NRamda.Add(3.345f, 243.342f).Should().Be(3.345f + 243.342f);
        }

        [Fact]
        public void CanAddTwoDoubles()
        {
            NRamda.Add(3.345d, 243.342d).Should().Be(3.345d + 243.342d);
        }

        [Fact]
        public void CanAddTwoDecimals()
        {
            NRamda.Add(50.45m, 243.42m).Should().Be(50.45m + 243.42m);
        }

        [Fact]
        public void CanAddTwoIntsWithPartialApplication()
        {
            NRamda.Add(2)(5).Should().Be(2 + 5);
        }

        [Fact]
        public void CanAddTwoFloatsWithPartialApplication()
        {
            NRamda.Add(3.345f)(243.342f).Should().Be(3.345f + 243.342f);
        }

        [Fact]
        public void CanAddTwoDoublesWithPartialApplication()
        {
            NRamda.Add(3.345d)(243.342d).Should().Be(3.345d + 243.342d);
        }

        [Fact]
        public void CanAddTwoDecimalsWithPartialApplication()
        {
            NRamda.Add(50.45m)(243.42m).Should().Be(50.45m + 243.42m);
        }
    }
}
