using System.IO;
using Common;
using Core.Signals;
using UnityEngine;
using Zenject;

namespace Core.PlayerProfile
{
    public class ProfileManager : IInitializable
    {
        private const string SAVINGS_FILE_PATH = "/profile.json";

        private JsonDataManager JsonDataManager { get; }
        private SignalBus SignalBus { get; }

        public ProfileData ProfileData;

        private bool SavingsFileExist => File.Exists(Application.persistentDataPath + SAVINGS_FILE_PATH);


        public ProfileManager(JsonDataManager jsonDataManager, SignalBus signalBus)
        {
            JsonDataManager = jsonDataManager;
            SignalBus = signalBus;
        }

        public void Initialize()
        {
            LoadData();
            ProfileData.OnSet += SaveData;
        }

        public void ResetData()
        {
            SignalBus.TryFire(new ResetPlayerDataSignal());

            ProfileData.Reset();
        }

        private void SaveData()
        {
            JsonDataManager.SaveData(SAVINGS_FILE_PATH, ProfileData);
        }

        private void LoadData()
        {
            if (SavingsFileExist)
            {
                ProfileData = JsonDataManager.LoadData<ProfileData>(SAVINGS_FILE_PATH);
            }
            else
            {
                ProfileData = new ProfileData();
                SaveData();
            }
        }
    }
}