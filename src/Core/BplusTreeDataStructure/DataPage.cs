using System;
using System.Collections.Generic;

namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class DataPage : IPage
    {
        private CustomerRecord[] _customers;

        public DataPage(
            int pageSize)
        {
            PageSize = pageSize;
            _customers = new CustomerRecord[pageSize + 1];
        }

        private DataPage(
            int pageSize,
            CustomerRecord[] customerRecords)
        {
            PageSize = pageSize;
            _customers = customerRecords;
        }

        public int PageSize { get; }

        private int PageSizePlusExtraSpace
        {
            get { return PageSize + 1; }
        }

        public InsertResult Insert(
            CustomerRecord customerRecord)
        {
            if (IsFull())
            {
                for (int pageIndex = 0; pageIndex < PageSizePlusExtraSpace; pageIndex++)
                {
                    if (_customers[pageIndex] == null)
                    {
                        _customers[pageIndex] = customerRecord;

                        break;
                    }

                    if (_customers[pageIndex].CustomerId > customerRecord.CustomerId)
                    {
                        _customers = InsertAndShiftWithFullPage(_customers, customerRecord, pageIndex);

                        break;
                    }
                }

                var splitCount = PageSize / 2;

                var leftDataPage = CreateLeftDataPage(splitCount);
                var rightDataPage = CreateRightDataPage(splitCount);

                return InsertResult.CreateAsSplit(
                    leftDataPage,
                    rightDataPage);
            }

            for (int pageIndex = 0; pageIndex < PageSize; pageIndex++)
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

        private DataPage CreateRightDataPage(int splitCount)
        {
            var rightCustomers = new CustomerRecord[PageSize + 1];
            Array.Copy(_customers, splitCount, rightCustomers, 0, PageSize - splitCount + 1);
            return new DataPage(PageSize, rightCustomers);
        }

        private DataPage CreateLeftDataPage(int splitCount)
        {
            var leftCustomers = new CustomerRecord[PageSize + 1];
            Array.Copy(_customers, 0, leftCustomers, 0, splitCount);
            return new DataPage(PageSize, leftCustomers);
        }

        private bool IsFull()
        {
            for (int i = 0; i < PageSize; i++)
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
            for (int indexCounter = PageSize - 1; indexCounter > insertIndex; indexCounter--)
            {
                dataPage[indexCounter] = dataPage[indexCounter - 1];
            }

            dataPage[insertIndex] = customerRecord;

            return dataPage;
        }

        private CustomerRecord[] InsertAndShiftWithFullPage(
            CustomerRecord[] dataPage,
            CustomerRecord customerRecord,
            int insertIndex)
        {
            for (int indexCounter = PageSizePlusExtraSpace - 1; indexCounter > insertIndex; indexCounter--)
            {
                dataPage[indexCounter] = dataPage[indexCounter - 1];
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
}