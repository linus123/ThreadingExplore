namespace ThreadingExplore.Core.BplusTreeDataStructure
{
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