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
    }
}