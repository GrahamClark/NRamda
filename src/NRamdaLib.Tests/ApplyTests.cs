using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class ApplyTests
    {
        [Fact]
        public void AppliesFunctionToArgumentList()
        {
            NRamda.Apply(VariadicMax, new[] { 1, 2, 3, -99, 42, 6, 7 }).Should().Be(42);
        }

        [Fact]
        public void IsCurried()
        {
            NRamda.Apply<int, int>(VariadicMax)(new[] { 1, 2, 3, -99, 42, 6, 7 }).Should().Be(42);
        }

        private static int VariadicMax(params int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers[0];
            }

            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }
    }
}
