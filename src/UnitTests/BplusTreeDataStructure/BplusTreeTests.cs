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

            var savedCustomer = tree.Select(100);

            savedCustomer.HasValue.Should().BeTrue();

            savedCustomer.Value.CustomerId.Should().Be(100);
            savedCustomer.Value.Name.Should().Be("Customer 100");
        }

        [Fact]
        public void ShouldWorkWithTwoDataPages()
        {
            var tree = new BplusTree();

            var customer01 = new CustomerRecord(100, "Customer 100");
            tree.Insert(customer01);

            var cusomter02 = new CustomerRecord(101, "Customer 101");
            tree.Insert(cusomter02);

            var customers = tree.GetAll();

            customers.Should().HaveCount(2);

            customers[0].CustomerId.Should().Be(100);
            customers[0].Name.Should().Be("Customer 100");

            customers[1].CustomerId.Should().Be(101);
            customers[1].Name.Should().Be("Customer 101");
        }

        [Fact]
        public void ShouldWorkWithTwoDataPagesOutOfOrder()
        {
            var tree = new BplusTree();

            var cusomter02 = new CustomerRecord(101, "Customer 101");
            tree.Insert(cusomter02);

            var customer01 = new CustomerRecord(100, "Customer 100");
            tree.Insert(customer01);

            var customers = tree.GetAll();

            customers.Should().HaveCount(2);

            customers[0].CustomerId.Should().Be(100);
            customers[0].Name.Should().Be("Customer 100");

            customers[1].CustomerId.Should().Be(101);
            customers[1].Name.Should().Be("Customer 101");
        }


    }
}