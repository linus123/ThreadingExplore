namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public class InsertResult
    {
        public static InsertResult CreateWithoutSplit()
        {
            return new InsertResult()
            {
                WasSplitCaused = false
            };
        }

        public static InsertResult CreateAsSplit(
            int splitValue,
            DataPage leftDataPage,
            DataPage rightDataPage)
        {
            return new InsertResult()
            {
                WasSplitCaused = true,
                SplitValue = splitValue,
                LeftDataPage = leftDataPage,
                RightDataPage = rightDataPage
            };
        }

        public bool WasSplitCaused { get; private set; }
        public int SplitValue { get; private set; }
        public DataPage LeftDataPage { get; private set; }
        public DataPage RightDataPage { get; private set; }

    }
}