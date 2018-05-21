using FluentAssertions;
using ThreadingExplore.Core.BplusTreeDataStructure;
using Xunit;

namespace ThreadingExplore.UnitTests.BplusTreeDataStructure
{
    public class BplusTreeThreeCountTests
    {
        private const int PageCount = 3;

        [Fact]
        public void SortedItemInsert()
        {
            var tree = new BplusTree(PageCount);

            tree.GetStringVersion().Should().BeEmpty();

            tree.Insert(CreateCustomer(100));
            tree.GetStringVersion().Should().Be("P:100");

            tree.Insert(CreateCustomer(110));
            tree.GetStringVersion().Should().Be("P:100|P:110");

            tree.Insert(CreateCustomer(120));
            tree.GetStringVersion().Should().Be("P:100|P:110|P:120");

            tree.Insert(CreateCustomer(130));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:120|P:120|P:130");

            tree.Insert(CreateCustomer(140));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:120|P:120|P:130|P:140");
        }

        [Fact]
        public void LeftMostSplit()
        {
            var tree = new BplusTree(PageCount);

            tree.GetStringVersion().Should().BeEmpty();

            tree.Insert(CreateCustomer(100));
            tree.GetStringVersion().Should().Be("P:100");

            tree.Insert(CreateCustomer(110));
            tree.GetStringVersion().Should().Be("P:100|P:110");

            tree.Insert(CreateCustomer(120));
            tree.GetStringVersion().Should().Be("P:100|P:110|P:120");

            tree.Insert(CreateCustomer(130));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:120|P:120|P:130");

            tree.Insert(CreateCustomer(111));
            tree.GetStringVersion().Should().Be("P:100|P:110|P:111|I:120|P:120|P:130");

            tree.Insert(CreateCustomer(112));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:111|P:111|P:112|I:120|P:120|P:130");
        }

        [Fact]
        public void MiddleSplit()
        {
            var tree = new BplusTree(PageCount);

            tree.GetStringVersion().Should().BeEmpty();

            tree.Insert(CreateCustomer(100));
            tree.GetStringVersion().Should().Be("P:100");

            tree.Insert(CreateCustomer(110));
            tree.GetStringVersion().Should().Be("P:100|P:110");

            tree.Insert(CreateCustomer(120));
            tree.GetStringVersion().Should().Be("P:100|P:110|P:120");

            tree.Insert(CreateCustomer(130));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:120|P:120|P:130");

            tree.Insert(CreateCustomer(111));
            tree.GetStringVersion().Should().Be("P:100|P:110|P:111|I:120|P:120|P:130");

            tree.Insert(CreateCustomer(112));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:111|P:111|P:112|I:120|P:120|P:130");

            tree.Insert(CreateCustomer(113));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:111|P:111|P:112|P:113|I:120|P:120|P:130");

            tree.Insert(CreateCustomer(114));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:111|P:111|P:112|I:113|P:113|P:114|I:120|P:120|P:130");
        }

        [Fact]
        public void RightSplit()
        {
            var tree = new BplusTree(PageCount);

            tree.GetStringVersion().Should().BeEmpty();

            tree.Insert(CreateCustomer(100));
            tree.GetStringVersion().Should().Be("P:100");

            tree.Insert(CreateCustomer(110));
            tree.GetStringVersion().Should().Be("P:100|P:110");

            tree.Insert(CreateCustomer(120));
            tree.GetStringVersion().Should().Be("P:100|P:110|P:120");

            tree.Insert(CreateCustomer(130));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:120|P:120|P:130");

            tree.Insert(CreateCustomer(140));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:120|P:120|P:130|P:140");

            tree.Insert(CreateCustomer(150));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:120|P:120|P:130|I:140|P:140|P:150");
        }

        [Fact]
        public void BalancedInsert()
        {
            var tree = new BplusTree(PageCount);

            tree.GetStringVersion().Should().BeEmpty();

            var customerRecord1 = CreateCustomer(500);
            tree.Insert(customerRecord1);
            tree.GetStringVersion().Should().Be("P:500");

            var customerRecord2 = CreateCustomer(400);
            tree.Insert(customerRecord2);
            tree.GetStringVersion().Should().Be("P:400|P:500");

            var customerRecord3 = CreateCustomer(300);
            tree.Insert(customerRecord3);
            tree.GetStringVersion().Should().Be("P:300|P:400|P:500");

            var customerRecord4 = CreateCustomer(350);
            tree.Insert(customerRecord4);
            tree.GetStringVersion().Should().Be("P:300|P:350|I:400|P:400|P:500");

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