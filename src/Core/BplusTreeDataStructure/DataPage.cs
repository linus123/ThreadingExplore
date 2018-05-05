namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class DataPage
    {
        public DataPage(
            int customerId,
            string name)
        {
            Name = name;
            CustomerId = customerId;
        }

        public int CustomerId { get; }
        public string Name { get; }
    }

    public class CustomerRecord
    {
        public CustomerRecord(
            int customerId,
            string name)
        {
            Name = name;
            CustomerId = customerId;
        }

        public int CustomerId { get; }
        public string Name { get; }

    }
}