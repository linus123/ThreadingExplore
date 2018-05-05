namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class BplusTree
    {
        private CustomerRecord _customerRecord;

        public void Insert(CustomerRecord customerRecord)
        {
            _customerRecord = customerRecord;
        }

        public Maybe<CustomerRecord> Select(int customerId)
        {
            return Maybe<CustomerRecord>.Some(_customerRecord);
        }
    }
}