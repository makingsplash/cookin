using System;

namespace Core.Consumables
{
    [Serializable]
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