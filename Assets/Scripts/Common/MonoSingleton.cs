using UnityEngine;

namespace Common
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = (T) this;

                DontDestroyOnLoad(gameObject);

                Initialize();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected virtual void Initialize()
        {
        }
    }
}