using System;
using Newtonsoft.Json;

namespace Core.Game.Savings
{
    [Serializable]
    public class ProfileData
    {
        [JsonProperty(nameof(IsSoundsEnabled))]
        private bool _isSoundsEnabled = true;

        [JsonProperty(nameof(IsMusicEnabled))]
        private bool _isMusicEnabled = true;

        [JsonProperty(nameof(Stars))]
        private int _stars;

        [JsonProperty(nameof(Diamonds))]
        private int _diamonds;

        [JsonIgnore]
        public Action OnSave;


        [JsonIgnore]
        public bool IsSoundsEnabled
        {
            get => _isSoundsEnabled;
            set => Set(ref _isSoundsEnabled, value);
        }

        [JsonIgnore]
        public bool IsMusicEnabled
        {
            get => _isMusicEnabled;
            set => Set(ref _isMusicEnabled, value);
        }

        [JsonIgnore]
        public int Stars
        {
            get => _stars;
            set => Set(ref _stars, value);
        }

        [JsonIgnore]
        public int Diamonds
        {
            get => _diamonds;
            set => Set(ref _diamonds, value);
        }

        private void Set<T>(ref T field, T value)
        {
            if (Equals(field, value))
            {
                return;
            }

            field = value;
            OnSave?.Invoke();
        }
    }
}