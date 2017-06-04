using System;

using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class AllPassTests
    {
        private readonly Func<int, bool> _odd = x => x % 2 != 0;
        private readonly Func<int, bool> _lt20 = x => x < 20;
        private readonly Func<int, bool> _gt5 = x => x > 5;
        private readonly Func<int, int, int, int, bool> _plusEq = (w, x, y, z) => w + x == y + z;

        [Fact]
        public void CanTestTwoPredicates()
        {
            // slightly modified from the example in the documentation
            // as this is using a class instead of an associative array
            Func<Card, bool> isQueen = c => c.Rank == 'Q';
            Func<Card, bool> isSpade = c => c.Suit == '♠';

            var isQueenOfSpades = NRamda.AllPass(new[] {isQueen, isSpade});

            isQueenOfSpades(new Card {Rank = 'Q', Suit = '♣'}).Should().BeFalse();
            isQueenOfSpades(new Card {Rank = 'Q', Suit = '♠' }).Should().BeTrue();
        }

        [Fact]
        public void ReportsWhetherAllPredicatesAreSatisfiedByAGivenValue()
        {
            var ok = NRamda.AllPass(new[] {_odd, _lt20, _gt5});

            ok(7).Should().BeTrue();
            ok(9).Should().BeTrue();
            ok(10).Should().BeFalse();
            ok(3).Should().BeFalse();
            ok(21).Should().BeFalse();
        }

        [Fact]
        public void ReturnsTrueOnEmptyPredicateList()
        {
            NRamda.AllPass(new Func<int,bool>[0])(3).Should().BeTrue();
        }

        private class Card
        {
            public char Rank { get; set; }

            public char Suit { get; set; }
        }
    }
}
