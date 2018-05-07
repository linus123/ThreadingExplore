namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class InsertResult
    {
        public static InsertResult CreateInsertSuccess()
        {
            return new InsertResult()
            {
                WasSplitCaused = false
            };
        }

        public static InsertResult CreateAsSplit(
            DataPage leftDataPage,
            DataPage rightDataPage)
        {
            return new InsertResult()
            {
                WasSplitCaused = true,
                LeftDataPage = leftDataPage,
                RightDataPage = rightDataPage
            };
        }

        public bool WasSplitCaused { get; private set; }
        public DataPage LeftDataPage { get; private set; }
        public DataPage RightDataPage { get; private set; }

    }
}