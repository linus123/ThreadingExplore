namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class InsertResult
    {
        public static InsertResult CreateInsertSuccess()
        {
            return new InsertResult()
            {
                WasSuccessful = true
            };
        }

        public static InsertResult CreateAsSplit(
            DataPage leftDataPage,
            DataPage rightDataPage)
        {
            return new InsertResult()
            {
                WasSuccessful = false,
                LeftDataPage = leftDataPage,
                RightDataPage = rightDataPage
            };
        }

        public bool WasSuccessful { get; private set; }
        public DataPage LeftDataPage { get; private set; }
        public DataPage RightDataPage { get; private set; }

    }
}