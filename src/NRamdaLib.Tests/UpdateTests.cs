using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class UpdateTests
    {
        [Fact]
        public void CanUpdateListValue()
        {
            NRamda.Update(1, 11, new[] { 0, 1, 2 }).ShouldBeEquivalentTo(new[] { 0, 11, 2 });
        }

        [Fact]
        public void IsCurried()
        {
            NRamda.Update<int>(1)(11)(new[] { 0, 1, 2 }).ShouldBeEquivalentTo(new[] { 0, 11, 2 });
        }

        [Fact]
        public void OffsetsNegativeIndexesFromTheEndOfTheList()
        {
            NRamda.Update(-3, 4, new[] { 0, 1, 2, 3 }).ShouldBeEquivalentTo(new[] { 0, 4, 2, 3 });
        }

        [Fact]
        public void DoesNotMutateTheOriginalCollection()
        {
            var list = new[] { 0, 1, 2, 3 };
            NRamda.Update(2, 4, list).ShouldBeEquivalentTo(new[] { 0, 1, 4, 3 });
            list.ShouldBeEquivalentTo(new[] { 0, 1, 2, 3 });
        }

        [Fact]
        public void ReturnsTheOriginalListIfTheIndexIsOutOfBounds()
        {
            var list = new[] { 0, 1, 2, 3 };
            NRamda.Update(4, 4, list).ShouldBeEquivalentTo(list);
            NRamda.Update(-5, 4, list).ShouldBeEquivalentTo(list);
        }
    }
}
