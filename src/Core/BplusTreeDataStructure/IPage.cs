using System.Text;

namespace ThreadingExplore.Core.BplusTreeDataStructure
{
    public interface IPage
    {
        int PageSize { get; }

        InsertResult Insert(
            CustomerRecord newCustomerRecord);

        CustomerRecord[] GetAll();

        void AppendString(
            StringBuilder sb);
    }
}