using System;
using Core.Consumables;
using Core.Game.Savings;
using Zenject;

namespace Core.PlayerProfile
{
    public class ProfileManager : IInitializable
    {
        private SavingsManager SavingsManager { get; }

        public ProfileData ProfileData;


        public ProfileManager(SavingsManager savingsManager)
        {
            SavingsManager = savingsManager;
        }

        public void Initialize()
        {
            ProfileData = SavingsManager.LoadData();
            ProfileData.OnSave += () => SavingsManager.SaveData(ProfileData);
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