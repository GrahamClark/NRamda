﻿using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class ReduceTests
    {
        [Fact]
        public void CanReduceWithSubtract()
        {
            var reduced = NRamda.Reduce(NRamda.Subtract, 0, new[] {1, 2, 3, 4});

            reduced.Should().Be(-10);
        }

        [Fact]
        public void ReturnsAccumulatorForEmptyCollection()
        {
            var reduced = NRamda.Reduce(NRamda.Add, 1, new int[0]);

            reduced.Should().Be(1);
        }
    }
}
