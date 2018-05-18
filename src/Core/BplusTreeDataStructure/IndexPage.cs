using System.Collections.Generic;

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

            _indexes = new int[pageSize];
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

        public InsertResult Insert(CustomerRecord newCustomerRecord)
        {
            if (newCustomerRecord.CustomerId < _indexes[0])
            {
                return _dataPages[0].Insert(newCustomerRecord);
            }

            var insertResult = _dataPages[1].Insert(newCustomerRecord);

            if (insertResult.WasSplitCaused)
            {
                _indexes[1] = insertResult.SplitValue;
                _dataPages[1] = insertResult.LeftDataPage;
                _dataPages[2] = insertResult.RightDataPage;
            }

            return InsertResult.CreateWithoutSplit();
        }
    }
}