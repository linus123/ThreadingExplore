namespace ThreadingExplore.Core.BankersAlgorithm
{
    public class BankProcessResource
    {

        public BankProcessResource(
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