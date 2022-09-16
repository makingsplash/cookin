using Core.Consumables;

namespace Core.Signals
{
    public class ConsumableAmountChangedSignal
    {
        public readonly ConsumableType ConsumableType;
        public readonly int OldAmount;
        public readonly int NewAmount;

        public ConsumableAmountChangedSignal(ConsumableType consumableType, int newAmount, int oldAmount = 0)
        {
            ConsumableType = consumableType;
            NewAmount = newAmount;
            OldAmount = oldAmount;
        }
    }
}