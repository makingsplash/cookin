using System;
using Core.Consumables;

namespace Core.PlayerProfile
{
    public class ProfileManager
    {
        public bool IsMusicEnabled;
        public bool IsSoundsEnabled;

        private int _starsAmount;
        private int _diamondsAmount;

        public ProfileManager()
        {
            IsMusicEnabled = false;
            IsSoundsEnabled = true;
        }

        public int GetConsumableAmount(ConsumableType consumableType)
        {
            return consumableType switch
            {
                ConsumableType.Star => _starsAmount,
                ConsumableType.Diamond => _diamondsAmount,
                _ => throw new ArgumentOutOfRangeException(nameof(consumableType), consumableType, null)
            };
        }

        public void SetConsumableAmount(ConsumableType consumableType, int newAmount)
        {
            switch(consumableType)
            {
                case ConsumableType.Star:
                    _starsAmount = newAmount;
                    break;
                case ConsumableType.Diamond:
                    _diamondsAmount = newAmount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(consumableType), consumableType, null);
            }
        }
    }
}