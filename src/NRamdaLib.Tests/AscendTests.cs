using System;
using System.Collections.Generic;

using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class AscendTests
    {
        [Fact]
        public void CanSortListAscendingWithIdentity()
        {
            var list = new List<int> { 3, 1, 8, 1, 2, 5 };
            Func<int, int> listIdentity = NRamda.Identity;

            var sorted = NRamda.Ascend(listIdentity).Sort(list);

            sorted.ShouldBeEquivalentTo(new[] { 1, 1, 2, 3, 5, 8 });
        }
    }
}
