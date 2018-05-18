using System.Text;

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

            if (insertResult.WasSplitCaused)
            {
                _dataPage = new IndexPage(
                    _dataPage.PageSize,
                    insertResult.SplitValue,
                    insertResult.LeftDataPage,
                    insertResult.RightDataPage);
            }
        }

        public CustomerRecord[] GetAll()
        {
            return _dataPage.GetAll();
        }

        public string GetStringVersion()
        {
            var sb = new StringBuilder();

            _dataPage.AppendString(sb);

            return sb.ToString();
        }
    }
}