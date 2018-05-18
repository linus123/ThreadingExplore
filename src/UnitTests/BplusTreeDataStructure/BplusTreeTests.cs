using FluentAssertions;
using ThreadingExplore.Core.BplusTreeDataStructure;
using Xunit;

namespace ThreadingExplore.UnitTests.BplusTreeDataStructure
{
    public class BplusTreeTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldNotErrorWithZeroRecords(
            int pageSize)
        {
            var tree = new BplusTree(pageSize);

            var customers = tree.GetAll();

            customers.Should().HaveCount(0);

            var stringVersion = tree.GetStringVersion();
            stringVersion.Should().BeEmpty();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldStoreSingleRecord(
            int pageSize)
        {
            var tree = new BplusTree(pageSize);

            var customerRecord = CreateCustomer(100);
            tree.Insert(customerRecord);

            var customers = tree.GetAll();

            customers.Should().HaveCount(1);

            customers[0].CustomerId.Should().Be(100);
            customers[0].Name.Should().Be(customerRecord.Name);

            var stringVersion = tree.GetStringVersion();
            stringVersion.Should().Be("P:100");

        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldStoreTwoRecord(
            int pageSize)
        {
            var tree = new BplusTree(pageSize);

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

            var stringVersion = tree.GetStringVersion();
            stringVersion.Should().Be("P:100|P:101");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldStoreTwoRecrodsOutOfOrder(
            int pageSize)
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

            var stringVersion = tree.GetStringVersion();
            stringVersion.Should().Be("P:100|P:101");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldStoreThreeRecords(
            int pageSize)
        {
            var tree = new BplusTree(pageSize);

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

            var stringVersion = tree.GetStringVersion();
            stringVersion.Should().Be("P:100|P:101|P:102");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldStoreThreeRecordsOutOfOrder1(
            int pageSize)
        {
            var tree = new BplusTree(pageSize);

            var cusomter02 = CreateCustomer(101);
            tree.Insert(cusomter02);

            var customer01 = CreateCustomer(100);
            tree.Insert(customer01);

            var cusomter03 = CreateCustomer(102);
            tree.Insert(cusomter03);

            var customers = tree.GetAll();

            customers.Should().HaveCount(3);

            customers[0].CustomerId.Should().Be(100);
            customers[1].CustomerId.Should().Be(101);
            customers[2].CustomerId.Should().Be(102);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldStoreThreeRecordsOutOfOrder2(
            int pageSize)
        {
            var tree = new BplusTree(pageSize);

            var cusomter03 = CreateCustomer(102);
            tree.Insert(cusomter03);

            var cusomter02 = CreateCustomer(101);
            tree.Insert(cusomter02);

            var customer01 = CreateCustomer(100);
            tree.Insert(customer01);

            var customers = tree.GetAll();

            customers.Should().HaveCount(3);

            customers[0].CustomerId.Should().Be(100);
            customers[1].CustomerId.Should().Be(101);
            customers[2].CustomerId.Should().Be(102);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldStoreFourInOrder(
            int pageSize)
        {
            var tree = new BplusTree(pageSize);

            var customer01 = CreateCustomer(100);
            tree.Insert(customer01);

            var cusomter02 = CreateCustomer(110);
            tree.Insert(cusomter02);

            var cusomter03 = CreateCustomer(120);
            tree.Insert(cusomter03);

            var cusomter04 = CreateCustomer(105);
            tree.Insert(cusomter04);

            var customers = tree.GetAll();

            customers.Should().HaveCount(4);

            customers[0].CustomerId.Should().Be(100);
            customers[1].CustomerId.Should().Be(105);
            customers[2].CustomerId.Should().Be(110);
            customers[3].CustomerId.Should().Be(120);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldStoreFourInOrder2(
            int pageSize)
        {
            var tree = new BplusTree(pageSize);

            var customer01 = CreateCustomer(100);
            tree.Insert(customer01);

            var cusomter02 = CreateCustomer(110);
            tree.Insert(cusomter02);

            var cusomter03 = CreateCustomer(120);
            tree.Insert(cusomter03);

            var cusomter04 = CreateCustomer(130);
            tree.Insert(cusomter04);

            var customers = tree.GetAll();

            customers.Should().HaveCount(4);

            customers[0].CustomerId.Should().Be(100);
            customers[1].CustomerId.Should().Be(110);
            customers[2].CustomerId.Should().Be(120);
            customers[3].CustomerId.Should().Be(130);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Test910(
            int pageSize)
        {
            var tree = new BplusTree(pageSize);

            var customer01 = CreateCustomer(100);
            tree.Insert(customer01);

            var cusomter02 = CreateCustomer(110);
            tree.Insert(cusomter02);

            var cusomter03 = CreateCustomer(120);
            tree.Insert(cusomter03);

            var cusomter04 = CreateCustomer(105);
            tree.Insert(cusomter04);

            var cusomter05 = CreateCustomer(130);
            tree.Insert(cusomter05);

            var customers = tree.GetAll();

            customers.Should().HaveCount(5);

            customers[0].CustomerId.Should().Be(100);
            customers[1].CustomerId.Should().Be(105);
            customers[2].CustomerId.Should().Be(110);
            customers[3].CustomerId.Should().Be(120);
            customers[4].CustomerId.Should().Be(130);
        }


        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Test900(
            int pageSize)
        {
            var tree = new BplusTree(pageSize);

            var customer01 = CreateCustomer(100);
            tree.Insert(customer01);

            var cusomter02 = CreateCustomer(110);
            tree.Insert(cusomter02);

            var cusomter03 = CreateCustomer(120);
            tree.Insert(cusomter03);

            var cusomter04 = CreateCustomer(105);
            tree.Insert(cusomter04);

            var cusomter05 = CreateCustomer(130);
            tree.Insert(cusomter05);

            var cusomter06 = CreateCustomer(115);
            tree.Insert(cusomter06);

            var customers = tree.GetAll();

            customers.Should().HaveCount(6);

            customers[0].CustomerId.Should().Be(100);
            customers[1].CustomerId.Should().Be(105);
            customers[2].CustomerId.Should().Be(110);
            customers[3].CustomerId.Should().Be(115);
            customers[4].CustomerId.Should().Be(120);
            customers[5].CustomerId.Should().Be(130);
        }


        public CustomerRecord CreateCustomer(
            int customerId)
        {
            return new CustomerRecord(
                customerId,
                $"Customer {customerId,3}");
        }

    }
}