﻿using FluentAssertions;
using ThreadingExplore.Core.DiningPhilosophers;
using Xunit;

namespace ThreadingExplore.UnitTests.DiningPhilosophers
{
    public class PhilosopherTableTests
    {
        [Fact(DisplayName = "TryToEatAtPlace should return true when no one is eating.")]
        public void Test1()
        {
            var philosopherTable = new Butler(2);

            var tryToEatAtPlace = philosopherTable.TryToEatAtPlace(0);

            tryToEatAtPlace.CanEat.Should().BeTrue();
        }

        [Fact(DisplayName = "TryToEatAtPlace should return false person to my right is eading.")]
        public void Test2()
        {
            var philosopherTable = new Butler(3);

            var tryToEatAtPlace1 = philosopherTable.TryToEatAtPlace(0);
            var tryToEatAtPlace2 = philosopherTable.TryToEatAtPlace(1);
            tryToEatAtPlace2.CanEat.Should().BeFalse();
            tryToEatAtPlace2.Message.Should().Be("Left fork free: False ... Right fork free: True");
        }

        [Fact(DisplayName = "TryToEatAtPlace should return false person to my left is eading.")]
        public void Test10()
        {
            var philosopherTable = new Butler(3);

            var tryToEatAtPlace1 = philosopherTable.TryToEatAtPlace(1);
            var tryToEatAtPlace2 = philosopherTable.TryToEatAtPlace(0);
            tryToEatAtPlace2.CanEat.Should().BeFalse();
            tryToEatAtPlace2.Message.Should().Be("Left fork free: True ... Right fork free: False");
        }

        [Fact(DisplayName = "TryToEatAtPlace should not error when eating is on last chair.")]
        public void Test3()
        {
            var philosopherTable = new Butler(3);

            var tryToEatAtPlace1 = philosopherTable.TryToEatAtPlace(2);
            tryToEatAtPlace1.CanEat.Should().BeTrue();
        }

        [Fact(DisplayName = "TryToEatAtPlace should return false when first place is eating and last place tries to eat.")]
        public void Test4()
        {
            var philosopherTable = new Butler(3);

            var tryToEatAtPlace1 = philosopherTable.TryToEatAtPlace(0);
            var tryToEatAtPlace2 = philosopherTable.TryToEatAtPlace(2);
            tryToEatAtPlace2.CanEat.Should().BeFalse();
            tryToEatAtPlace2.Message.Should().Be("Left fork free: True ... Right fork free: False");
        }

    }
}