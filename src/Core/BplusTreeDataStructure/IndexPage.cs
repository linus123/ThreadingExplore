using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class IndexPage : IPage
    {
        private readonly int[] _indexes;
        private readonly IPage[] _dataPages;

        public IndexPage(
            int pageSize,
            int splitValue,
            IPage dataPage1,
            IPage dataPage2)
        {
            PageSize = pageSize;

            _indexes = new int[pageSize + 1];
            _indexes[0] = splitValue;
            _dataPages = new IPage[pageSize + 2];

            _dataPages[0] = dataPage1;
            _dataPages[1] = dataPage2;
        }

        public int PageSize { get; }

        public CustomerRecord[] GetAll()
        {
            var customerRecords = new List<CustomerRecord>();

            foreach (var dataPage in _dataPages)
            {
                if (dataPage == null)
                    break;

                customerRecords.AddRange(dataPage.GetAll());
            }

            return customerRecords.ToArray();
        }

        public void AppendString(StringBuilder sb)
        {
            _dataPages[0].AppendString(sb);

            for (int i = 0; i < PageSize; i++)
            {
                if (_dataPages[i + 1] == null)
                    break;

                sb.AppendFormat("|I:{0}|", _indexes[i]);

                _dataPages[i + 1].AppendString(sb);
            }
        }

        public InsertResult Insert(CustomerRecord newCustomerRecord)
        {
            var indexToInsert = FindIndexToInsert(newCustomerRecord);

            var insertResult = _dataPages[indexToInsert].Insert(newCustomerRecord);

            if (insertResult.WasSplitCaused)
            {
                if (_indexes[indexToInsert] > 0)
                {
                    // ** Slide
                    for (int i = PageSize; i > indexToInsert; i--)
                    {
                        _indexes[i] = _indexes[i - 1];
                    }

                    // ** Slide
                    for (int i = PageSize + 1; i > indexToInsert; i--)
                    {
                        _dataPages[i] = _dataPages[i - 1];
                    }

                }

                _indexes[indexToInsert] = insertResult.SplitValue;
                _dataPages[indexToInsert] = insertResult.LeftDataPage;
                _dataPages[indexToInsert + 1] = insertResult.RightDataPage;
            }

            if (_indexes[PageSize] > 0)
            {
                var leftPage = new IndexPage(PageSize, _indexes[0], _dataPages[0], _dataPages[1]);
                var rightPage = new IndexPage(PageSize, _indexes[2], _dataPages[2], _dataPages[3]);

                return InsertResult.CreateAsSplit(_indexes[1], leftPage, rightPage);
            }

            return InsertResult.CreateWithoutSplit();

        }

        private int FindIndexToInsert(CustomerRecord newCustomerRecord)
        {
            for (var i = 0; i < PageSize + 1; i++)
            {
                if (_indexes[i] <= 0 || newCustomerRecord.CustomerId < _indexes[i])
                {
                    return i;
                }
            }

            throw new Exception("Something is wrong");
        }
    }
}