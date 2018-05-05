using System;
using System.Collections.Generic;

namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class DataPage
    {
        private CustomerRecord[] _customers;

        private readonly int _pageSize;

        public DataPage(
            int pageSize)
        {
            _pageSize = pageSize;
            _customers = new CustomerRecord[pageSize + 1];
        }

        private DataPage(
            int pageSize,
            CustomerRecord[] customerRecords)
        {
            _pageSize = pageSize;
            _customers = customerRecords;
        }

        public InsertResult Insert(
            CustomerRecord customerRecord)
        {
            if (IsFull())
            {
                for (int pageIndex = 0; pageIndex < _pageSize + 1; pageIndex++)
                {
                    if (_customers[pageIndex] == null)
                    {
                        _customers[pageIndex] = customerRecord;

                        break;
                    }

                    if (_customers[pageIndex].CustomerId > customerRecord.CustomerId)
                    {
                        _customers = InsertAndShift(_customers, customerRecord, pageIndex);

                        break;
                    }
                }

                var splitCount = _pageSize / 2;

                var leftCustomers = new CustomerRecord[_pageSize + 1];
                Array.Copy(_customers, 0, leftCustomers, 0, splitCount);
                var leftDataPage = new DataPage(_pageSize, leftCustomers);

                var rightCustomers = new CustomerRecord[_pageSize + 1];
                Array.Copy(_customers, splitCount, rightCustomers, 0, _pageSize - splitCount + 1);
                var rightDataPage = new DataPage(_pageSize, rightCustomers);

                return InsertResult.CreateAsSplit(
                    leftDataPage,
                    rightDataPage);
            }

            for (int pageIndex = 0; pageIndex < _pageSize; pageIndex++)
            {
                if (_customers[pageIndex] == null)
                {
                    _customers[pageIndex] = customerRecord;

                    return InsertResult.CreateInsertSuccess();
                }

                if (_customers[pageIndex].CustomerId > customerRecord.CustomerId)
                {
                    _customers = InsertAndShift(_customers, customerRecord, pageIndex);

                    return InsertResult.CreateInsertSuccess();
                }
            }

            throw new Exception("Something bad happend");
        }

        private bool IsFull()
        {
            for (int i = 0; i < _pageSize; i++)
            {
                if (_customers[i] == null)
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

            foreach (var customerRecord in _customers)
            {
                if (customerRecord != null)
                    customerRecords.Add(customerRecord);
            }

            return customerRecords.ToArray();
        }
    }

    public class InsertResult
    {
        public static InsertResult CreateInsertSuccess()
        {
            return new InsertResult()
            {
                WasSuccessful = true
            };
        }

        public static InsertResult CreateAsSplit(
            DataPage leftDataPage,
            DataPage rightDataPage)
        {
            return new InsertResult()
            {
                WasSuccessful = false,
                LeftDataPage = leftDataPage,
                RightDataPage = rightDataPage
            };
        }

        public bool WasSuccessful { get; private set; }
        public DataPage LeftDataPage { get; private set; }
        public DataPage RightDataPage { get; private set; }

    }
}