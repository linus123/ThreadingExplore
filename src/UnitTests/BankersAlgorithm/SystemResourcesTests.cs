using FluentAssertions;
using ThreadingExplore.Core.BankersAlgorithim;
using ThreadingExplore.Core.SystemLog;
using Xunit;

namespace ThreadingExplore.UnitTests.BankersAlgorithim
{
    public class SystemResourcesTests
    {
        [Fact(DisplayName = "HasEnoughResources should return false when system has not resources.")]
        public void Test1()
        {
            var systemResources = new[]
            {
                new SystemResource(ResourceName.A, 0),
                new SystemResource(ResourceName.B, 0),
            };

            var system = new SystemResources(systemResources, new NoOpSystemLog());

            var processResources = new[]
            {
                new BankProcessResource(ResourceName.A, 1),
                new BankProcessResource(ResourceName.B, 1),
            };

            var process = new BankProcess("P1", 100, processResources);

            system.ClaimResources(process).Should().BeFalse();
            system.GetSystemSummary().Should().Be("Name A - Cur:0 Max:0 | Name B - Cur:0 Max:0");
        }

        [Fact(DisplayName = "HasEnoughResources should return true when system has exactly the needed resources.")]
        public void Test2()
        {
            var systemResources = new []
            {
                new SystemResource(ResourceName.A, 1),
                new SystemResource(ResourceName.B, 1),
            };

            var system = new SystemResources(systemResources, new NoOpSystemLog());

            var processResources = new[]
            {
                new BankProcessResource(ResourceName.A, 1), 
                new BankProcessResource(ResourceName.B, 1),
            };

            var process = new BankProcess("P1", 100, processResources);

            system.ClaimResources(process).Should().BeTrue();
            system.GetSystemSummary().Should().Be("Name A - Cur:0 Max:1 | Name B - Cur:0 Max:1");
        }

        [Fact(DisplayName = "HasEnoughResources should return true when system more than enough resources.")]
        public void Test3()
        {
            var systemResources = new[]
            {
                new SystemResource(ResourceName.A, 2),
                new SystemResource(ResourceName.B, 3),
            };

            var system = new SystemResources(systemResources, new NoOpSystemLog());

            var processResources = new[]
            {
                new BankProcessResource(ResourceName.A, 1),
                new BankProcessResource(ResourceName.B, 1),
            };

            var process = new BankProcess("P1", 100, processResources);

            system.ClaimResources(process).Should().BeTrue();
            system.GetSystemSummary().Should().Be("Name A - Cur:1 Max:2 | Name B - Cur:2 Max:3");
        }

        [Fact(DisplayName = "HasEnoughResources should return false when there are enough resources except one.")]
        public void Test4()
        {
            var systemResources = new[]
            {
                new SystemResource(ResourceName.A, 2),
                new SystemResource(ResourceName.B, 1),
                new SystemResource(ResourceName.C, 3),
            };

            var system = new SystemResources(systemResources, new NoOpSystemLog());

            var processResources = new[]
            {
                new BankProcessResource(ResourceName.A, 1),
                new BankProcessResource(ResourceName.B, 2),
                new BankProcessResource(ResourceName.C, 1),
            };

            var process = new BankProcess("P1", 100, processResources);

            system.ClaimResources(process).Should().BeFalse();
            system.GetSystemSummary().Should().Be("Name A - Cur:2 Max:2 | Name B - Cur:1 Max:1 | Name C - Cur:3 Max:3");
        }

        [Fact(DisplayName = "RestoreResources should restore resources as expected.")]
        public void Test5()
        {
            var systemResources = new[]
            {
                new SystemResource(ResourceName.A, 10),
                new SystemResource(ResourceName.B, 9),
                new SystemResource(ResourceName.C, 3),
            };

            var system = new SystemResources(systemResources, new NoOpSystemLog());

            var processResources = new[]
            {
                new BankProcessResource(ResourceName.A, 1),
                new BankProcessResource(ResourceName.B, 2),
                new BankProcessResource(ResourceName.C, 1),
            };

            var process = new BankProcess("P1", 100, processResources);

            system.ClaimResources(process).Should().BeTrue();
            system.GetSystemSummary().Should().Be("Name A - Cur:9 Max:10 | Name B - Cur:7 Max:9 | Name C - Cur:2 Max:3");
            system.RestoreResources(process);
            system.GetSystemSummary().Should().Be("Name A - Cur:10 Max:10 | Name B - Cur:9 Max:9 | Name C - Cur:3 Max:3");
        }

    }
}