﻿using System.Collections.Generic;

namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class IndexPage : IPage
    {
        private int _pageSize;
        private int[] _indexes;
        private DataPage[] _dataPages;

        public IndexPage(
            int pageSize,
            DataPage dataPage1,
            DataPage dataPage2)
        {
            _pageSize = pageSize;

            _indexes = new int[pageSize];
            _dataPages = new DataPage[pageSize + 1];

            _dataPages[0] = dataPage1;
            _dataPages[1] = dataPage2;
        }

        public int PageSize
        {
            get { return _pageSize; }
        }

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

        public InsertResult Insert(CustomerRecord customerRecord)
        {
            throw new System.NotImplementedException();
        }
    }
}