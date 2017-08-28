using System;

using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class NoneTests
    {
        private readonly Func<int, bool> _isEven = x => x % 2 == 0;

        [Fact]
        public void ReturnsTrueIfNoElementsSatisfyThePredicate()
        {
            _isEven.None(new[] { 1, 3, 5, 7, 9, 11 }).Should().BeTrue();
        }

        [Fact]
        public void ReturnsFalseIfAnyElementsSatisfyThePredicate()
        {
            _isEven.None(new[] { 1, 3, 5, 7, 8, 11 }).Should().BeFalse();
        }

        [Fact]
        public void ReturnsTrueForAnEmptyList()
        {
            Func<int, bool> t = x => true;
            t.None(new int[0]).Should().BeTrue();
        }

        [Fact]
        public void IsCurried()
        {
            NRamda.None(_isEven)(new[] { 1, 3, 5, 6, 7, 9 }).Should().BeFalse();
        }

        [Fact]
        public void WorksWithComplexObjects()
        {
            var people = new[] { new Person("Bob"), new Person("Henry"), new Person("Alexander") };
            Func<Person, bool> len4 = p => p.Name.Length == 4;
            Func<Person, bool> hasE = p => p.Name.Contains("e");

            NRamda.None(len4, people).Should().BeTrue();
            NRamda.None(hasE, people).Should().BeFalse();
        }

        private class Person
        {
            public Person(string name)
            {
                Name = name;
            }

            public string Name { get; }
        }
    }
}
