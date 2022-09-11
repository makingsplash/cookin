using System.IO;
using UnityEngine;

namespace Core.Game.Savings
{
    public class SavingsManager
    {
        private const string SAVINGS_FILE_PATH = "/profile.json";

        private JsonDataManager JsonDataManager { get; }

        private bool SavingsFileExist => File.Exists(Application.persistentDataPath + SAVINGS_FILE_PATH);


        public SavingsManager(JsonDataManager jsonDataManager)
        {
            JsonDataManager = jsonDataManager;
        }

        public void SaveData(ProfileData profileData)
        {
            JsonDataManager.SaveData(SAVINGS_FILE_PATH, profileData);
        }

        public ProfileData LoadData()
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