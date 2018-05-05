using FluentAssertions;
using ThreadingExplore.Core.BplusTreeDataStructure;
using Xunit;

namespace ThreadingExplore.UnitTests.BplusTreeDataStructure
{
    public class BplusTreeTests
    {
        [Fact]
        public void ShouldWorkWithSingleDataPage()
        {
            var tree = new BplusTree();

            var customerRecord = new CustomerRecord(100, "Customer 100");

            tree.Insert(customerRecord);

            var savedDataPage = tree.Select(100);

            savedDataPage.HasValue.Should().BeTrue();

            savedDataPage.Value.CustomerId.Should().Be(100);
            savedDataPage.Value.Name.Should().Be("Customer 100");
        }

        [Fact]
        public void ShouldWorkWithTwoDataPages()
        {
            var tree = new BplusTree();

            var customer01 = new CustomerRecord(100, "Customer 100");
            tree.Insert(customer01);

            var cusomter02 = new CustomerRecord(101, "Customer 101");
            tree.Insert(cusomter02);

            var savedDataPage = tree.Select(101);

            savedDataPage.HasValue.Should().BeTrue();
            savedDataPage.Value.CustomerId.Should().Be(101);
            savedDataPage.Value.Name.Should().Be("Customer 101");
        }

    }
}