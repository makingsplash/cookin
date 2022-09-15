using Core.Consumables;

namespace Core.Game.Signals
{
    public class ConsumableAmountChangedSignal
    {
        public readonly ConsumableType ConsumableType;
        public readonly int OldAmount;
        public readonly int NewAmount;

        public ConsumableAmountChangedSignal(ConsumableType consumableType, int oldAmount, int newAmount)
        {
            ConsumableType = consumableType;
            OldAmount = oldAmount;
            NewAmount = newAmount;
        }
    }
}