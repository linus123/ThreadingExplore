namespace ThreadingExplore.Core.BankersAlgorithim
{
    public class ProcessResource
    {

        public ProcessResource(
            ResourceName resourceName,
            int maxAmount)
        {
            Name = resourceName;
            MaxAmount = maxAmount;
        }

        public ResourceName Name { get; }
        public int MaxAmount { get; }
    }
}