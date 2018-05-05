using System;
using System.Collections.Generic;

namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class DataPage
    {
        private CustomerRecord[] _dataPage;

        private readonly int _pageSize;

        public DataPage(
            int pageSize)
        {
            _pageSize = pageSize;
            _dataPage = new CustomerRecord[pageSize + 1];
        }

        public bool Insert(
            CustomerRecord customerRecord)
        {
            if (IsFull())
                return false;

            for (int pageIndex = 0; pageIndex < _pageSize; pageIndex++)
            {
                if (_dataPage[pageIndex] == null)
                {
                    _dataPage[pageIndex] = customerRecord;

                    return true;
                }

                if (_dataPage[pageIndex].CustomerId > customerRecord.CustomerId)
                {
                    _dataPage = InsertAndShift(_dataPage, customerRecord, pageIndex);

                    return true;
                }
            }

            throw new Exception("Something bad happend");
        }

        private bool IsFull()
        {
            for (int i = 0; i < _pageSize; i++)
            {
                if (_dataPage[i] == null)
                    return false;
            }

            return true;
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


    }
}