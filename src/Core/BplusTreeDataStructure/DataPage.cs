using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class DataPage : IPage
    {
        private CustomerRecord[] _customerRecords;

        private enum AdditionalSpaceAction
        {
            DoNoUseAddtionalSpace,
            UseAddtionalSpace
        }

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

        private int PageSizePlusAdditionalSpace
        {
            get { return PageSize + 1; }
        }

        public InsertResult Insert(
            CustomerRecord newCustomerRecord)
        {
            if (IsDataPageFull())
                return InsertAndSplit(newCustomerRecord);

            return InsertWithoutSplit(
                newCustomerRecord,
                AdditionalSpaceAction.DoNoUseAddtionalSpace);
        }

        private InsertResult InsertAndSplit(
            CustomerRecord newCustomerRecord)
        {
            InsertWithoutSplit(
                newCustomerRecord,
                AdditionalSpaceAction.UseAddtionalSpace);

            return CreateSplitResult(_customerRecords);
        }

        private InsertResult InsertWithoutSplit(
            CustomerRecord newCustomerRecord,
            AdditionalSpaceAction additionalSpaceAction)
        {
            var pageSize = GetCorrectPageSize(additionalSpaceAction);

            for (int recordIndex = 0; recordIndex < pageSize; recordIndex++)
            {
                if (_customerRecords[recordIndex] == null)
                {
                    _customerRecords[recordIndex] = newCustomerRecord;

                    break;
                }

                if (_customerRecords[recordIndex].CustomerId > newCustomerRecord.CustomerId)
                {
                    _customerRecords = ShiftAndInsert(
                        _customerRecords,
                        newCustomerRecord,
                        recordIndex, pageSize);

                    break;
                }
            }

            return InsertResult.CreateWithoutSplit();
        }

        private int GetCorrectPageSize(
            AdditionalSpaceAction additionalSpaceAction)
        {
            if (additionalSpaceAction == AdditionalSpaceAction.UseAddtionalSpace)
                return PageSizePlusAdditionalSpace;

            return PageSize;
        }

        private InsertResult CreateSplitResult(
            CustomerRecord[] customerRecords)
        {
            var splitCount = (int) Math.Ceiling(PageSize / 2.0d);

            var leftDataPage = CreateLeftDataPage(customerRecords, splitCount);
            var rightDataPage = CreateRightDataPage(customerRecords, splitCount);

            return InsertResult.CreateAsSplit(
                customerRecords[splitCount].CustomerId,
                leftDataPage,
                rightDataPage);
        }

        private DataPage CreateLeftDataPage(
            CustomerRecord[] customerRecords,
            int splitCount)
        {
            var leftCustomers = new CustomerRecord[PageSizePlusAdditionalSpace];
            Array.Copy(customerRecords, 0, leftCustomers, 0, splitCount);
            return new DataPage(PageSize, leftCustomers);
        }

        private DataPage CreateRightDataPage(
            CustomerRecord[] customerRecords,
            int splitCount)
        {
            var rightCustomers = new CustomerRecord[PageSizePlusAdditionalSpace];
            Array.Copy(customerRecords, splitCount, rightCustomers, 0, PageSize - splitCount + 1);
            return new DataPage(PageSize, rightCustomers);
        }

        private bool IsDataPageFull()
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
            ShiftCustomers(customerRecords, insertIndex, pageSize);

            customerRecords[insertIndex] = newCustomerRecord;

            return customerRecords;
        }

        private static void ShiftCustomers(
            CustomerRecord[] customerRecords,
            int insertIndex,
            int pageSize)
        {
            for (int i = pageSize - 1; i > insertIndex; i--)
            {
                customerRecords[i] = customerRecords[i - 1];
            }
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

        public void AppendString(
            StringBuilder sb)
        {
            var customerStrings = new List<string>();

            foreach (var c in _customerRecords)
            {
                if (c == null)
                    break;

                customerStrings.Add(c.GetIndexString());
            }

            sb.AppendFormat(string.Join("|", customerStrings));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            AppendString(sb);

            return sb.ToString();
        }
    }
}