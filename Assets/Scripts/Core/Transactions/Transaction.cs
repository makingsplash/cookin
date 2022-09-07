using Core.Consumables;

namespace Core.Transactions
{
    public class Transaction
    {
        public readonly ConsumableType ConsumableType;
        public readonly int Amount;

        public Transaction(ConsumableType consumableType, int amount)
        {
            ConsumableType = consumableType;
            Amount = amount;
        }
    }
}