using System;
using Core.PlayerProfile;

namespace Core.Consumables
{
    public class ConsumablesManager
    {
        private ProfileManager ProfileManager { get; }
        private ProfileData ProfileData => ProfileManager.ProfileData;

        public ConsumablesManager(ProfileManager profileManager)
        {
            ProfileManager = profileManager;
        }

        public int GetConsumableAmount(ConsumableType consumableType)
        {
            return consumableType switch
            {
                ConsumableType.Star => ProfileData.Stars,
                ConsumableType.Diamond => ProfileData.Diamonds,
                _ => throw new ArgumentOutOfRangeException(nameof(consumableType), consumableType, null)
            };
        }

        public void SetConsumableAmount(ConsumableType consumableType, int newAmount)
        {
            switch(consumableType)
            {
                case ConsumableType.Star:
                    ProfileData.Stars = newAmount;
                    break;
                case ConsumableType.Diamond:
                    ProfileData.Diamonds = newAmount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(consumableType), consumableType, null);
            }
        }
    }
}