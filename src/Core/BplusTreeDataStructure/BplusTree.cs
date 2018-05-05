using System.Collections.Generic;

namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class BplusTree
    {
        private CustomerRecord[] _dataPage;
        private readonly int _pageSize;

        public BplusTree(
            int pageSize = 2)
        {
            _pageSize = pageSize;
            _dataPage = new CustomerRecord[pageSize];
        }

        public void Insert(CustomerRecord customerRecord)
        {
            for (int pageIndex = 0; pageIndex < _pageSize; pageIndex++)
            {
                if (_dataPage[pageIndex] == null)
                {
                    _dataPage[pageIndex] = customerRecord;

                    return;
                }

                if (IsDataPageFull(_dataPage))
                {
                    return;
                }

                if (_dataPage[pageIndex].CustomerId > customerRecord.CustomerId)
                {
                    _dataPage = InsertAndShift(_dataPage, customerRecord, pageIndex);

                    return;
                }
            }
        }

        public CustomerRecord[] GetAll()
        {
            var customerRecords = new List<CustomerRecord>();

            foreach (var customerRecord in _dataPage)
            {
                if (customerRecord != null)
                    customerRecords.Add(customerRecord);
            }

            return customerRecords.ToArray();
        }

        private CustomerRecord[] InsertAndShift(
            CustomerRecord[] dataPage,
            CustomerRecord customerRecord,
            int insertIndex)
        {
            for (int indexCounter = insertIndex; indexCounter < (_pageSize - 1); indexCounter++)
            {
                dataPage[insertIndex + 1] = dataPage[insertIndex];
            }

            dataPage[insertIndex] = customerRecord;

            return dataPage;
        }

        private bool IsDataPageFull(
            CustomerRecord[] dataPage)
        {
            for (int i = 0; i < _pageSize; i++)
            {
                if (dataPage[i] == null)
                    return false;
            }

            return true;
        }
    }

}