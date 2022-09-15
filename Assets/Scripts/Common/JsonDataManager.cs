using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Common
{
    public class JsonDataManager
    {
        public bool SaveData<T>(string relativePath, T data)
        {
            string path = Application.persistentDataPath + relativePath;

            try
            {
                // temp, rewrite fields
                if (!File.Exists(path))
                {
                    File.Delete(path);
                }

                CreateFile(path);

                File.WriteAllText(path, JsonConvert.SerializeObject(data, Formatting.Indented));

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public T LoadData<T>(string relativePath)
        {
            string path = Application.persistentDataPath + relativePath;

            if (!File.Exists(path))
            {
                CreateFile(path);
            }

            try
            {
                T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void CreateFile(string path)
        {
            using FileStream stream = File.Create(path);
            stream.Close();
        }
    }
}