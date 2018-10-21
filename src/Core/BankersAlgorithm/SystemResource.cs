using System;

namespace ThreadingExplore.Core.BankersAlgorithm
{
    public class SystemResource
    {
        private readonly int _maxAmount;

        public SystemResource(
            ResourceName resourceName,
            int maxAmount)
        {
            Name = resourceName;
            _maxAmount = maxAmount;
            CurrentAmount = maxAmount;
        }

        public ResourceName Name { get; }
        public int CurrentAmount { get; private set; }

        public string GetSummary()
        {
            return $"Name {Name} - Cur:{CurrentAmount} Max:{_maxAmount}";
        }

        public void ClaimResourceCount(
            int resourceCount)
        {
            CurrentAmount = CurrentAmount - resourceCount;

            if (CurrentAmount < 0)
                throw new Exception("System is negative resources");
        }

        public void RestoreResourceCount(
            int resourceCount)
        {
            CurrentAmount = CurrentAmount + resourceCount;

            if (CurrentAmount > _maxAmount)
                throw new Exception("System has more than max");
        }
    }
}