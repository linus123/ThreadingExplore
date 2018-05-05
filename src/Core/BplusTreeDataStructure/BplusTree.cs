using System.Collections.Generic;

namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class BplusTree
    {
        private DataPage _dataPage;
        private IndexPage _indexPage;

        private int _pageSize;

        public BplusTree(
            int pageSize = 2)
        {
            _pageSize = pageSize;
            _dataPage = new DataPage(pageSize);
        }

        public void Insert(CustomerRecord customerRecord)
        {
            var insertResult = _dataPage.Insert(customerRecord);

            if (insertResult.WasSuccessful)
                return;

            _indexPage = new IndexPage(
                _pageSize,
                insertResult.LeftDataPage,
                insertResult.RightDataPage);
        }

        public CustomerRecord[] GetAll()
        {
            if (_indexPage != null)
                return _indexPage.GetAll();

            return _dataPage.GetAll();
        }
    }

    public class IndexPage
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
    }

}