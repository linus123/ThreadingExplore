﻿using System.Collections.Generic;
using System.Text;

namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class IndexPage : IPage
    {
        private readonly int[] _indexes;
        private readonly DataPage[] _dataPages;

        public IndexPage(
            int pageSize,
            int splitValue,
            DataPage dataPage1,
            DataPage dataPage2)
        {
            PageSize = pageSize;

            _indexes = new int[pageSize + 1];
            _indexes[0] = splitValue;
            _dataPages = new DataPage[pageSize + 1];

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
            var indexToInsertFindResult = FindIndexToInsert(newCustomerRecord);

            if (indexToInsertFindResult.IsLast)
            {
                return null;
            }

            var insertResult = _dataPages[indexToInsertFindResult.Index].Insert(newCustomerRecord);

            if (insertResult.WasSplitCaused)
            {
                _indexes[indexToInsertFindResult.Index] = insertResult.SplitValue;
                _dataPages[indexToInsertFindResult.Index] = insertResult.LeftDataPage;
                _dataPages[indexToInsertFindResult.Index + 1] = insertResult.RightDataPage;
            }

            return InsertResult.CreateWithoutSplit();

        }

        private IndexToInsertFindResult FindIndexToInsert(CustomerRecord newCustomerRecord)
        {
            for (var i = 0; i < PageSize; i++)
            {
                if (_indexes[i] <= 0 || newCustomerRecord.CustomerId < _indexes[i])
                {
                    return new IndexToInsertFindResult()
                    {
                        Index = i,
                        IsLast = false
                    };
                }
            }

            return new IndexToInsertFindResult()
            {
                IsLast = true
            };
    }

        private struct IndexToInsertFindResult
        {
            public int Index { get; set; }
            public bool IsLast { get; set; }
        }
    }
}