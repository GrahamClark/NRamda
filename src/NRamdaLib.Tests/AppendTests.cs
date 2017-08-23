using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class AppendTests
    {
        [Fact]
        public void CanAppendItemToList()
        {
            var appendedInt = 4.Append(new[] { 1, 2, 3 });
            appendedInt.ShouldBeEquivalentTo(new[] { 1, 2, 3, 4 });

            var appendedString = "you".Append(new[] { "hello", "there" });
            appendedString.ShouldAllBeEquivalentTo(new[] { "hello", "there", "you" });
        }

        [Fact]
        public void WorksOnAnEmptyList()
        {
            1.Append(new int[0]).ShouldBeEquivalentTo(new[] { 1 });
        }

        [Fact]
        public void IsCurried()
        {
            var appender = 4.Append();
            appender(new[] { 1, 2, 3 }).ShouldBeEquivalentTo(new[] { 1, 2, 3, 4 });
        }
    }
}
