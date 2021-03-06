﻿using System;

using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class AllPassTests
    {
        private readonly Func<int, bool> _odd = x => x % 2 != 0;
        private readonly Func<int, bool> _lt20 = x => x < 20;
        private readonly Func<int, bool> _gt5 = x => x > 5;
        private readonly Func<int, int, bool> _sumLt100 = (x, y) => x + y < 100;

        private readonly Func<int, int, bool> _bothDivisibleBy5 =
            (x, y) => x % 5 == 0 && y % 5 == 0;

        private readonly Func<int, int, int, int, bool> _plusEq = (w, x, y, z) => w + x == y + z;

        [Fact]
        public void CanTestTwoPredicates()
        {
            // slightly modified from the example in the documentation
            // as this is using a class instead of an associative array
            Func<Card, bool> isQueen = c => c.Rank == 'Q';
            Func<Card, bool> isSpade = c => c.Suit == '♠';

            var isQueenOfSpades = new[] {isQueen, isSpade}.AllPass();

            isQueenOfSpades(new Card {Rank = 'Q', Suit = '♣'}).Should().BeFalse();
            isQueenOfSpades(new Card {Rank = 'Q', Suit = '♠' }).Should().BeTrue();
        }

        [Fact]
        public void ReportsWhetherAllPredicatesAreSatisfiedByAGivenValue()
        {
            var ok = new[] {_odd, _lt20, _gt5}.AllPass();

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

        [Fact]
        public void UncurriedWith2ParamPredicates()
        {
            var ok = new[] {_sumLt100, _bothDivisibleBy5}.AllPass();

            ok(10, 35).Should().BeTrue();
            ok(45, 65).Should().BeFalse();
            ok(10, 27).Should().BeFalse();
        }

        [Fact]
        public void CurriedWith2ParamPredicates()
        {
            var ok = new[] {_sumLt100, _bothDivisibleBy5}.AllPassCurried();

            ok(10)(35).Should().BeTrue();
            ok(45)(65).Should().BeFalse();
            ok(10)(27).Should().BeFalse();
        }

        [Fact]
        public void UncurriedWith4ParamPredicate()
        {
            var ok = new[] { _plusEq }.AllPass();

            ok(3, 4, 5, 2).Should().BeTrue();
            ok(6, 6, 5, 5).Should().BeFalse();
        }

        [Fact]
        public void CurriedWith4ParamPredicate()
        {
            var ok = new[] { _plusEq }.AllPassCurried();

            ok(3)(4)(5)(2).Should().BeTrue();
            ok(6)(6)(5)(5).Should().BeFalse();
        }

        [Fact]
        public void WorksWithSortOfVariadicFunctions()
        {
            var ok = new[] {_odd, _lt20, _gt5}.AllPassVariadic();
            ok(new[] { 7, 13, 9, 11 }).Should().BeTrue();
        }

        private class Card
        {
            public char Rank { get; set; }

            public char Suit { get; set; }
        }
    }
}
