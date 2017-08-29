using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class DropTests
    {
        [Fact]
        public void CanDropItemsFromCollection()
        {
            var list = new[] { "foo", "bar", "baz" };
            NRamda.Drop(1, list).ShouldBeEquivalentTo(new[] { "bar", "baz" });
            NRamda.Drop(2, list).ShouldBeEquivalentTo(new[] { "baz" });
            NRamda.Drop(3, list).Should().BeEmpty();
            NRamda.Drop(4, list).Should().BeEmpty();

            NRamda.Drop(3, "ramda").Should().Be("da");
        }

        [Fact]
        public void IsCurried()
        {
            var drop3 = NRamda.Drop<int>(3);

            drop3(new[] { 1, 2, 3, 4 }).ShouldBeEquivalentTo(new[] { 4 });
            drop3(new[] { 10, 20, 30, 40, 50, 60 }).ShouldBeEquivalentTo(new[] { 40, 50, 60 });
        }
    }
}
