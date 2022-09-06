using Core.PlayerProfile;
using Core.UI.Elements.Screen;
using UnityEngine;

namespace Core.Game.UI.Screen
{
    public class SettingsScreenViewPresenter : ScreenViewPresenter
    {
        private SettingsScreenView SettingsScreenView => (SettingsScreenView) View;
        private ProfileManager ProfileManager { get; }


        public SettingsScreenViewPresenter(ProfileManager profileManager)
            : base("Assets/GameAssets/Home/Prefabs/SettingsScreen.prefab")
        {
            ProfileManager = profileManager;
        }

        public override void InitializeView()
        {
            SettingsScreenView.SoundsToggle.isOn = ProfileManager.IsSoundsEnabled;
            SettingsScreenView.MusicToggle.isOn = ProfileManager.IsMusicEnabled;

            base.InitializeView();
        }

        protected override void BindView()
        {
            base.BindView();

            SettingsScreenView.SoundsToggle.onValueChanged.AddListener(OnSoundsToggleChanged);
            SettingsScreenView.MusicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
            SettingsScreenView.SupportButton.onClick.AddListener(OpenSupportPopup);
            SettingsScreenView.CloseButton.onClick.AddListener(SettingsScreenView.Close);
        }

        private void OnMusicToggleChanged(bool value)
        {
            ProfileManager.IsMusicEnabled = value;

            Debug.Log($"[{nameof(SettingsScreenViewPresenter)}]: Play music {ProfileManager.IsMusicEnabled}");
        }

        private void OnSoundsToggleChanged(bool value)
        {
            ProfileManager.IsSoundsEnabled = value;

            Debug.Log($"[{nameof(SettingsScreenViewPresenter)}]: Play sounds {ProfileManager.IsSoundsEnabled}");
        }

        private void OpenSupportPopup()
        {
            Debug.Log($"[{nameof(SettingsScreenViewPresenter)}]: Open support popup");
        }
    }
}