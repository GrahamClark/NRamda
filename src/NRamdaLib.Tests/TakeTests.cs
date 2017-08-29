using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class TakeTests
    {
        [Fact]
        public void CanTakeItemsFromCollection()
        {
            var list = new[] { "foo", "bar", "baz" };
            NRamda.Take(1, list).ShouldBeEquivalentTo(new[] { "foo" });
            NRamda.Take(2, list).ShouldBeEquivalentTo(new[] { "foo", "bar" });
            NRamda.Take(3, list).ShouldBeEquivalentTo(new[] { "foo", "bar", "baz" });
            NRamda.Take(4, list).ShouldBeEquivalentTo(new[] { "foo", "bar", "baz" });

            NRamda.Take(3, "ramda").Should().Be("ram");
        }

        [Fact]
        public void HandlesZeroCorrectly()
        {
            NRamda.Take(0, new[] { 1, 2, 3, 4 }).Should().BeEmpty();
        }

        [Fact]
        public void IsCurried()
        {
            var take2 = NRamda.Take<int>(2);

            take2(new[] { 3, 4, 5, 6 }).ShouldBeEquivalentTo(new[] { 3, 4 });
            take2(new[] { 100, 200, 300 }).ShouldBeEquivalentTo(new[] { 100, 200 });
        }
    }
}
