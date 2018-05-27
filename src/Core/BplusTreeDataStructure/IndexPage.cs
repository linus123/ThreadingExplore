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

        public IndexPage(
            int pageSize,
            int[] indexes,
            IPage[] dataPages)
        {
            PageSize = pageSize;

            _indexes = new int[pageSize + 1];

            for (int i = 0; i < indexes.Length; i++)
            {
                _indexes[i] = indexes[i];
            }

            _dataPages = new IPage[pageSize + 2];

            for (int i = 0; i < dataPages.Length; i++)
            {
                _dataPages[i] = dataPages[i];
            }
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
                    ShiftIndexes(indexToInsert);
                    ShiftPages(indexToInsert);
                }

                UpdateIndexsAndPages(indexToInsert, insertResult);
            }

            if (PageIsFull())
            {
                return CreateSplit();
            }

            return InsertResult.CreateWithoutSplit();
        }

        private void UpdateIndexsAndPages(
            int indexToInsert,
            InsertResult insertResult)
        {
            _indexes[indexToInsert] = insertResult.SplitValue;
            _dataPages[indexToInsert] = insertResult.LeftDataPage;
            _dataPages[indexToInsert + 1] = insertResult.RightDataPage;
        }

        private InsertResult CreateSplit()
        {
            var splitCount = (int) Math.Ceiling(PageSize / 2.0d);

            var leftPage = CreateLeftPage(splitCount);
            var rightPage = CreateRightPage(splitCount);

            return InsertResult.CreateAsSplit(
                _indexes[splitCount],
                leftPage,
                rightPage);
        }

        private bool PageIsFull()
        {
            return _indexes[PageSize] > 0;
        }

        private IndexPage CreateLeftPage(int splitCount)
        {
            var indexes = SubArray(_indexes, 0, splitCount);
            var pages = SubArray(_dataPages, 0, splitCount + 1);
            return new IndexPage(PageSize, indexes, pages);
        }

        private IndexPage CreateRightPage(int splitCount)
        {
            var indexes = SubArray(_indexes, splitCount + 1, PageSize - splitCount);
            var pages = SubArray(_dataPages, splitCount + 1, PageSize - splitCount + 1);
            return new IndexPage(PageSize, indexes, pages);
        }

        private void ShiftPages(int indexToInsert)
        {
            for (int i = PageSize + 1; i > indexToInsert; i--)
                _dataPages[i] = _dataPages[i - 1];
        }

        private void ShiftIndexes(int indexToInsert)
        {
            for (int i = PageSize; i > indexToInsert; i--)
                _indexes[i] = _indexes[i - 1];
        }

        private static T[] SubArray<T>(
            T[] data,
            int index,
            int length)
        {
            var result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        private int FindIndexToInsert(CustomerRecord cust)
        {
            for (var i = 0; i < PageSize + 1; i++)
            {
                if (_indexes[i] <= 0 || cust.CustomerId < _indexes[i])
                {
                    return i;
                }
            }

            throw new Exception("Something is wrong");
        }
    }
}