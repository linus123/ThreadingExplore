namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class BplusTree
    {
        private IPage _dataPage;
        
        public BplusTree(
            int pageSize = 2)
        {
            _dataPage = new DataPage(pageSize);
        }

        public void Insert(CustomerRecord customerRecord)
        {
            var insertResult = _dataPage.Insert(customerRecord);

            if (insertResult.WasSuccessful)
                return;

            _dataPage = new IndexPage(
                _dataPage.PageSize,
                insertResult.LeftDataPage,
                insertResult.RightDataPage);
        }

        public CustomerRecord[] GetAll()
        {
            return _dataPage.GetAll();
        }
    }
}