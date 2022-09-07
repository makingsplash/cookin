using System;

namespace Core.Consumables
{
    public enum ConsumableType
    {
        Star = 0,
        Diamond = 1
    }

    [Serializable]
    public class Consumable
    {
        public ConsumableType ConsumableType;

        public Consumable(ConsumableType consumableType)
        {
            ConsumableType = consumableType;
        }
    }
}