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
}