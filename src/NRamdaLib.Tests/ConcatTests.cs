using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class ConcatTests
    {
        [Fact]
        public void CanCombineTwoLists()
        {
            new[] {'a', 'b'}.Concat(new[] {'c', 'd'})
                  .Should()
                  .BeEquivalentTo(new[] {'a', 'b', 'c', 'd'});

            new char[0].Concat(new[] {'c', 'd'})
                  .Should()
                  .BeEquivalentTo(new[] {'c', 'd'});
        }

        [Fact]
        public void WorksWithStrings()
        {
            NRamda.Concat("hello ", "there")
                  .Should()
                  .BeEquivalentTo("hello there");
        }

        [Fact]
        public void IsCurried()
        {
            var conc123 = new[] {1, 2, 3}.Concat();
            conc123(new[] {4, 5, 6})
                .Should()
                .BeEquivalentTo(new[] {1, 2, 3, 4, 5, 6});
        }
    }
}
