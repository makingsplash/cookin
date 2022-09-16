using Core.PlayerProfile;
using Core.UI.Elements.Screen;
using UnityEngine;

namespace Core.Game.UI.Screen
{
    public class SettingsScreenViewPresenter : ScreenViewPresenter
    {
        private SettingsScreenView SettingsScreenView => (SettingsScreenView) View;
        private ProfileManager ProfileManager { get; }

        private ProfileData ProfileData => ProfileManager.ProfileData;


        public SettingsScreenViewPresenter(ProfileManager profileManager)
            : base("Assets/GameAssets/Home/Prefabs/SettingsScreen.prefab")
        {
            ProfileManager = profileManager;
        }

        public override void InitializeView()
        {
            SettingsScreenView.SoundsToggle.isOn = ProfileData.IsSoundsEnabled;
            SettingsScreenView.MusicToggle.isOn = ProfileData.IsMusicEnabled;

            base.InitializeView();
        }

        protected override void BindView()
        {
            SettingsScreenView.SoundsToggle.onValueChanged.AddListener(OnSoundsToggleChanged);
            SettingsScreenView.MusicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
            SettingsScreenView.SupportButton.onClick.AddListener(OpenSupportPopup);
            SettingsScreenView.CloseButton.onClick.AddListener(SettingsScreenView.Close);
            SettingsScreenView.ResetSavingsButton.onClick.AddListener(ResetSavings);

            base.BindView();
        }

        private void OnMusicToggleChanged(bool value)
        {
            ProfileData.IsMusicEnabled = value;

            Debug.Log($"[{nameof(SettingsScreenViewPresenter)}]: Play music {ProfileData.IsMusicEnabled}");
        }

        private void OnSoundsToggleChanged(bool value)
        {
            ProfileData.IsSoundsEnabled = value;

            Debug.Log($"[{nameof(SettingsScreenViewPresenter)}]: Play sounds {ProfileData.IsSoundsEnabled}");
        }

        private void OpenSupportPopup()
        {
            Debug.Log($"[{nameof(SettingsScreenViewPresenter)}]: Open support popup");
        }

        private void ResetSavings()
        {
            ProfileManager.ResetData();

            SettingsScreenView.MusicToggle.isOn = true;
            SettingsScreenView.SoundsToggle.isOn = true;
        }
    }
}