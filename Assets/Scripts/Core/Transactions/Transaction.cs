using Core.Consumables;

namespace Core.Transactions
{
    public class Transaction
    {
        public ConsumableType ConsumableType;
        public int Amount;

        public Transaction(ConsumableType consumableType, int amount)
        {
            ConsumableType = consumableType;
            Amount = amount;
        }
    }
}