namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public interface IPage
    {
        int PageSize { get; }
        InsertResult Insert(CustomerRecord customerRecord);
        CustomerRecord[] GetAll();
    }
}