namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class BplusTree
    {
        private DataPage _dataPage;

        public BplusTree(
            int pageSize = 2)
        {
            _dataPage = new DataPage(pageSize);
        }

        public void Insert(CustomerRecord customerRecord)
        {
            var isFull = _dataPage.Insert(customerRecord);

            if (isFull)
            {
                // split
            }
        }

        public CustomerRecord[] GetAll()
        {
            return _dataPage.GetAll();
        }
    }

}