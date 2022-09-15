using System.IO;
using Common;
using UnityEngine;
using Zenject;

namespace Core.PlayerProfile
{
    public class ProfileManager : IInitializable
    {
        private const string SAVINGS_FILE_PATH = "/profile.json";

        private JsonDataManager JsonDataManager { get; }


        public ProfileData ProfileData;

        private bool SavingsFileExist => File.Exists(Application.persistentDataPath + SAVINGS_FILE_PATH);


        public ProfileManager(JsonDataManager jsonDataManager)
        {
            JsonDataManager = jsonDataManager;
        }

        public void Initialize()
        {
            ProfileData = LoadData();
            ProfileData.OnSet += () => SaveData(ProfileData);
        }

        private void SaveData(ProfileData profileData)
        {
            JsonDataManager.SaveData(SAVINGS_FILE_PATH, profileData);
        }

        private ProfileData LoadData()
        {
            ProfileData data;

            if (SavingsFileExist)
            {
                data = JsonDataManager.LoadData<ProfileData>(SAVINGS_FILE_PATH);
            }
            else
            {
                data = new ProfileData();
                SaveData(data);
            }

            return data;
        }
    }
}