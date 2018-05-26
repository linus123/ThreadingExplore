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
            IPage leftDataPage,
            IPage rightDataPage)
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
        public IPage LeftDataPage { get; private set; }
        public IPage RightDataPage { get; private set; }

    }
}