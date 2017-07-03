using FluentAssertions;
using ThreadingExplore.Core.DiningPhilosophers;
using Xunit;

namespace ThreadingExplore.UnitTests.DiningPhilosophers
{
    public class PhilosopherTableTests
    {
        [Fact(DisplayName = "TryToEatAtPlace should return true when no one is eating.")]
        public void Test1()
        {
            var philosopherTable = new PhilosopherTable(4);

            var tryToEatAtPlace = philosopherTable.TryToEatAtPlace(0);

            tryToEatAtPlace.CanEat.Should().BeTrue();
        }
    }
}