using FluentAssertions;
using ThreadingExplore.Core.BplusTreeDataStructure;
using Xunit;

namespace ThreadingExplore.UnitTests.BplusTreeDataStructure
{
    public class BplusTreeTwoCountTests
    {
        private const int PageCount = 2;

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
            tree.GetStringVersion().Should().Be("P:100|I:110|P:110|P:120");

            tree.Insert(CreateCustomer(130));
            tree.GetStringVersion().Should().Be("P:100|I:110|P:110|I:120|P:120|P:130");

            tree.Insert(CreateCustomer(140));
            tree.GetStringVersion().Should().Be("P:100|I:110|P:110|I:120|P:120|I:130|P:130|P:140");
        }

        [Fact]
        public void LeftSplit()
        {
            var tree = new BplusTree(PageCount);

            tree.GetStringVersion().Should().BeEmpty();

            tree.Insert(CreateCustomer(100));
            tree.GetStringVersion().Should().Be("P:100");

            tree.Insert(CreateCustomer(110));
            tree.GetStringVersion().Should().Be("P:100|P:110");

            tree.Insert(CreateCustomer(120));
            tree.GetStringVersion().Should().Be("P:100|I:110|P:110|P:120");

            tree.Insert(CreateCustomer(105));
            tree.GetStringVersion().Should().Be("P:100|P:105|I:110|P:110|P:120");

            tree.Insert(CreateCustomer(106));
            tree.GetStringVersion().Should().Be("P:100|I:105|P:105|P:106|I:110|P:110|P:120");
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
            tree.GetStringVersion().Should().Be("P:100|I:110|P:110|P:120");

            tree.Insert(CreateCustomer(130));
            tree.GetStringVersion().Should().Be("P:100|I:110|P:110|I:120|P:120|P:130");

        }

        [Fact]
        public void BalancedInsert()
        {
            var tree = new BplusTree(PageCount);

            tree.GetStringVersion().Should().BeEmpty();

            tree.Insert(CreateCustomer(500));
            tree.GetStringVersion().Should().Be("P:500");

            tree.Insert(CreateCustomer(400));
            tree.GetStringVersion().Should().Be("P:400|P:500");

            tree.Insert(CreateCustomer(300));
            tree.GetStringVersion().Should().Be("P:300|I:400|P:400|P:500");

            tree.Insert(CreateCustomer(350));
            tree.GetStringVersion().Should().Be("P:300|P:350|I:400|P:400|P:500");
        }

        [Fact]
        public void HighLevelIndexSplit()
        {
            var tree = new BplusTree(PageCount);

            tree.GetStringVersion().Should().BeEmpty();

            tree.Insert(CreateCustomer(100));
            tree.GetStringVersion().Should().Be("P:100");

            tree.Insert(CreateCustomer(200));
            tree.GetStringVersion().Should().Be("P:100|P:200");

            tree.Insert(CreateCustomer(300));
            tree.GetStringVersion().Should().Be("P:100|I:200|P:200|P:300");

            tree.Insert(CreateCustomer(110));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:200|P:200|P:300");

            tree.Insert(CreateCustomer(400));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:200|P:200|I:300|P:300|P:400");

            tree.Insert(CreateCustomer(225));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:200|P:200|P:225|I:300|P:300|P:400");

            tree.Insert(CreateCustomer(230));
            tree.GetStringVersion().Should().Be("P:100|P:110|I:200|P:200|I:225|P:225|I:230|I:300|P:300|P:400");
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