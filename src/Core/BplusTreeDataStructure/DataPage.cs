using System;
using System.Collections.Generic;

namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class DataPage : IPage
    {
        private CustomerRecord[] _customerRecords;

        public DataPage(
            int pageSize)
        {
            PageSize = pageSize;
            _customerRecords = new CustomerRecord[pageSize + 1];
        }

        private DataPage(
            int pageSize,
            CustomerRecord[] customerRecordRecords)
        {
            PageSize = pageSize;
            _customerRecords = customerRecordRecords;
        }

        public int PageSize { get; }

        private int PageSizePlusExtraSpace
        {
            get { return PageSize + 1; }
        }

        public InsertResult Insert(
            CustomerRecord newCustomerRecord)
        {
            if (IsFull())
            {
                return InsertAndSplit(newCustomerRecord);
            }

            return InsertWithoutSplit(newCustomerRecord);
        }

        private InsertResult InsertWithoutSplit(
            CustomerRecord newCustomerRecord)
        {
            for (int recordIndex = 0; recordIndex < PageSize; recordIndex++)
            {
                if (_customerRecords[recordIndex] == null)
                {
                    _customerRecords[recordIndex] = newCustomerRecord;

                    break;
                }

                if (_customerRecords[recordIndex].CustomerId > newCustomerRecord.CustomerId)
                {
                    _customerRecords = ShiftAndInsert(_customerRecords, newCustomerRecord, recordIndex, PageSize);

                    break;
                }
            }

            return InsertResult.CreateInsertSuccess();
        }

        private InsertResult InsertAndSplit(
            CustomerRecord newCustomerRecord)
        {
            for (int recordIndex = 0; recordIndex < PageSizePlusExtraSpace; recordIndex++)
            {
                if (_customerRecords[recordIndex] == null)
                {
                    _customerRecords[recordIndex] = newCustomerRecord;

                    break;
                }

                if (_customerRecords[recordIndex].CustomerId > newCustomerRecord.CustomerId)
                {
                    _customerRecords = ShiftAndInsert(_customerRecords, newCustomerRecord, recordIndex, PageSizePlusExtraSpace);

                    break;
                }
            }

            return CreateSplitResult(_customerRecords);
        }

        private InsertResult CreateSplitResult(
            CustomerRecord[] customerRecords)
        {
            var splitCount = PageSize / 2;

            var leftDataPage = CreateLeftDataPage(customerRecords, splitCount);
            var rightDataPage = CreateRightDataPage(customerRecords, splitCount);

            return InsertResult.CreateAsSplit(
                leftDataPage,
                rightDataPage);
        }

        private DataPage CreateRightDataPage(
            CustomerRecord[] customerRecords, int splitCount)
        {
            var rightCustomers = new CustomerRecord[PageSizePlusExtraSpace];
            Array.Copy(customerRecords, splitCount, rightCustomers, 0, PageSize - splitCount + 1);
            return new DataPage(PageSize, rightCustomers);
        }

        private DataPage CreateLeftDataPage(
            CustomerRecord[] customerRecords, int splitCount)
        {
            var leftCustomers = new CustomerRecord[PageSizePlusExtraSpace];
            Array.Copy(customerRecords, 0, leftCustomers, 0, splitCount);
            return new DataPage(PageSize, leftCustomers);
        }

        private bool IsFull()
        {
            for (int i = 0; i < PageSize; i++)
            {
                if (_customerRecords[i] == null)
                    return false;
            }

            return true;
        }

        private CustomerRecord[] ShiftAndInsert(
            CustomerRecord[] customerRecords,
            CustomerRecord newCustomerRecord,
            int insertIndex,
            int pageSize)
        {
            for (int i = pageSize - 1; i > insertIndex; i--)
            {
                customerRecords[i] = customerRecords[i - 1];
            }

            customerRecords[insertIndex] = newCustomerRecord;

            return customerRecords;
        }

        public CustomerRecord[] GetAll()
        {
            var customerRecords = new List<CustomerRecord>();

            foreach (var customerRecord in _customerRecords)
            {
                if (customerRecord != null)
                    customerRecords.Add(customerRecord);
            }

            return customerRecords.ToArray();
        }
    }
}