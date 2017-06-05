using System;
using System.Collections.Generic;

using FluentAssertions;

using Xunit;

namespace NRamdaLib.Tests
{
    public class AnyTests
    {
        private readonly Func<int, bool> _odd = x => x % 2 == 1;
        private readonly Func<int, bool> _t = x => true;

        [Fact]
        public void ReturnsTrueIfAnyElementSatisfiesPredicate()
        {
            _odd.Any(new[] {2, 4, 6, 8, 10, 11, 12}).Should().BeTrue();
        }

        [Fact]
        public void ReturnsFalseIfAllElementsFailToSatisfyThePredicate()
        {
            _odd.Any(new[] {2, 4, 6, 8, 10, 12}).Should().BeFalse();
        }

        [Fact]
        public void WorksWithMoreComplexObjects()
        {
            var people = new List<Person>
            {
                new Person("Paul", "Grenier"),
                new Person("Mike", "Hurley"),
                new Person("Will", "Klein")
            };

            Func<Person, bool> alliterative = p => p.FirstName[0] == p.LastName[0];

            alliterative.Any(people).Should().BeFalse();
            people.Add(new Person("Scott", "Sauyet"));
            alliterative.Any(people).Should().BeTrue();
        }

        [Fact]
        public void CanUseAConfigurableFunction()
        {
            var teens = new[]
                {new Child("Alice", 14), new Child("Betty", 18), new Child("Tom", 17)};

            Func<int, Func<Child, bool>> atLeast = age => child => child.Age >= age;

            NRamda.Any(atLeast(16), teens).Should().BeTrue();
            NRamda.Any(atLeast(21), teens).Should().BeFalse();
        }

        [Fact]
        public void ReturnsFalseForAnEmptyList()
        {
            NRamda.Any(_t, new int[0]).Should().BeFalse();
        }

        [Fact]
        public void IsCurried()
        {
            NRamda.Any(_odd)(new[] {2, 4, 6, 7, 8, 10}).Should().BeTrue();
        }

        private class Person
        {
            public Person(string first, string last)
            {
                FirstName = first;
                LastName = last;
            }

            public string FirstName { get; }

            public string LastName { get; }
        }

        private class Child
        {
            public Child(string name, int age)
            {
                Name = name;
                Age = age;
            }

            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public string Name { get; }

            public int Age { get; }
        }
    }
}
