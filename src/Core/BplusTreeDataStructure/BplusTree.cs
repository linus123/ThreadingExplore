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

//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            var random = new Random();
//
//
//            var bplusTree = new BplusTree(4);
//
//            for (int i = 0; i < 1000000; i++)
//            {
//                var num = random.Next(1, 1000000);
//
//                bplusTree.Insert(new CustomerRecord(num, "Customer {num}"));
//            }
//
//            //var stringVersion = bplusTree.GetStringVersion();
//
//            //System.Console.WriteLine(stringVersion);
//        }
//    }
}