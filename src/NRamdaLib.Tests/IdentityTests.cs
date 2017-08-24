using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class IdentityTests
    {
        [Fact]
        public void ReturnsParameter()
        {
            NRamda.Identity(1).Should().Be(1);
            NRamda.Identity("yo").Should().Be("yo");
            NRamda.Identity("hello", "there").Should().Be("hello");
        }
    }
}
