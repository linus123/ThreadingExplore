namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class BplusTree
    {
        private CustomerRecord[] _dataPage;

        public BplusTree()
        {
            _dataPage = new CustomerRecord[2];
        }

        public void Insert(CustomerRecord customerRecord)
        {
            if (_dataPage[0] == null)
            {
                _dataPage[0] = customerRecord;
            }
            else
            {
                if (_dataPage[0].CustomerId > customerRecord.CustomerId)
                {
                    _dataPage[1] = _dataPage[0];
                    _dataPage[0] = customerRecord;
                }
                else
                {
                    _dataPage[1] = customerRecord;
                }
            }
        }

        public Maybe<CustomerRecord> Select(int customerId)
        {
            return Maybe<CustomerRecord>.Some(_dataPage[0]);
        }

        public CustomerRecord[] GetAll()
        {
            return _dataPage;
        }
    }

}