using FluentAssertions;
using ThreadingExplore.Core.BplusTreeDataStructure;
using Xunit;

namespace ThreadingExplore.UnitTests.BplusTreeDataStructure
{
    public class BplusTreeTests
    {
        [Fact]
        public void ShouldStoreSingleRecord()
        {
            var tree = new BplusTree();

            var customerRecord = CreateCustomer(100);

            tree.Insert(customerRecord);

            var customers = tree.GetAll();

            customers.Should().HaveCount(1);

            customers[0].CustomerId.Should().Be(100);
            customers[0].Name.Should().Be(customerRecord.Name);
        }

        [Fact]
        public void ShouldStoreTwoRecord()
        {
            var tree = new BplusTree();

            var customer01 = CreateCustomer(100);
            tree.Insert(customer01);

            var cusomter02 = CreateCustomer(101);
            tree.Insert(cusomter02);

            var customers = tree.GetAll();

            customers.Should().HaveCount(2);

            customers[0].CustomerId.Should().Be(100);
            customers[0].Name.Should().Be(customer01.Name);

            customers[1].CustomerId.Should().Be(101);
            customers[1].Name.Should().Be(cusomter02.Name);
        }

        [Fact]
        public void ShouldStoreTwoRecrodsOutOfOrder()
        {
            var tree = new BplusTree();

            var cusomter02 = CreateCustomer(101);
            tree.Insert(cusomter02);

            var customer01 = CreateCustomer(100);
            tree.Insert(customer01);

            var customers = tree.GetAll();

            customers.Should().HaveCount(2);

            customers[0].CustomerId.Should().Be(100);
            customers[1].CustomerId.Should().Be(101);
        }

        [Fact]
        public void ShouldStoreThreeRecords()
        {
            var tree = new BplusTree();

            var customer01 = CreateCustomer(100);
            tree.Insert(customer01);

            var cusomter02 = CreateCustomer(101);
            tree.Insert(cusomter02);

            var cusomter03 = CreateCustomer(102);
            tree.Insert(cusomter03);

            var customers = tree.GetAll();

            customers.Should().HaveCount(3);

            customers[0].CustomerId.Should().Be(100);
            customers[1].CustomerId.Should().Be(101);
            customers[2].CustomerId.Should().Be(102);
        }

        public CustomerRecord CreateCustomer(
            int customerId)
        {
            return new CustomerRecord(
                customerId,
                string.Format("Customer {0,3}", customerId));
        }

    }
}