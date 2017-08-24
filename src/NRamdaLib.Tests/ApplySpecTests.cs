using System;
using System.Collections.Generic;

using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class ApplySpecTests
    {
        [Fact]
        public void CanApplySpecificationToList()
        {
            Func<int, int, int> f1 = NRamda.Add;
            Func<int, int, int> f2 = NRamda.Multiply;
            var spec = new Dictionary<string, object>
            {
                ["sum"] = f1,
                ["nested"] = new Dictionary<string, object>
                {
                    ["mul"] = f2
                }
            };

            var result = spec.ApplySpec<int, int>(new[] { 2, 4 });
            result.ShouldBeEquivalentTo(new Dictionary<string, object>
            {
                ["sum"] = 6,
                ["nested"] = new Dictionary<string, object>
                {
                    ["mul"] = 8
                }
            });
        }
    }
}
