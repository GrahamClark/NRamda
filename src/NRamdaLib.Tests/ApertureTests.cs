using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class ApertureTests
    {
        private readonly int[] _list = { 1, 2, 3, 4, 5, 6, 7 };

        [Fact]
        public void ReturnsEmptyCollectionWhenNIsLargerThanCollectionLength()
        {
            NRamda.Aperture(4, new[] { 1, 2, 3 }).Should().BeEmpty();
            NRamda.Aperture(1, new int[0]).Should().BeEmpty();
        }

        [Fact]
        public void CreatesACollectionOfNTuplesFromACollection()
        {
            NRamda.Aperture(1, _list)
                  .ShouldBeEquivalentTo(
                      new[]
                      {
                          new[] { 1 }, new[] { 2 }, new[] { 3 }, new[] { 4 }, new[] { 5 },
                          new[] { 6 }, new[] { 7 }
                      });

            NRamda.Aperture(2, _list)
                  .ShouldBeEquivalentTo(
                      new[]
                      {
                          new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 4, 5 },
                          new[] { 5, 6 }, new[] { 6, 7 }
                      });

            NRamda.Aperture(3, _list)
                  .ShouldBeEquivalentTo(
                      new[]
                      {
                          new[] { 1, 2, 3 }, new[] { 2, 3, 4 }, new[] { 3, 4, 5 },
                          new[] { 4, 5, 6 }, new[] { 5, 6, 7 }
                      });

            NRamda.Aperture(4, new[] { 1, 2, 3, 4 })
                  .ShouldBeEquivalentTo(new[] { new[] { 1, 2, 3, 4 } });
        }

        [Fact]
        public void IsCurried()
        {
            var pairwise = NRamda.Aperture<int>(2);
            pairwise(_list)
                .ShouldBeEquivalentTo(
                    new[]
                    {
                        new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 4, 5 },
                        new[] { 5, 6 }, new[] { 6, 7 }
                    });
        }
    }
}
