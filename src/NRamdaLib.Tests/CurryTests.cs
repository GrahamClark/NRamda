using System;
using Xunit;

namespace NRamdaLib.Tests
{
    public class CurryTests
    {
        [Fact]
        public void CanCurryTwoParameterFunction()
        {
            Func<int, int, int> add = (x, y) => x + y;
            var curriedAdd = NRamda.Curry(add);

            Assert.Equal(curriedAdd(3)(4), add(3, 4));
        }
    }
}
