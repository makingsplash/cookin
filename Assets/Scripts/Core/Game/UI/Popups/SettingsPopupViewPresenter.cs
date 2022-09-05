using Core.PlayerProfile;
using Core.UI.Elements.Popup;
using UnityEngine;

namespace Core.Game.UI.Popups
{
    public class SettingsPopupViewPresenter : PopupViewPresenter
    {
        private SettingsPopupView SettingsPopupView => (SettingsPopupView) View;
        private ProfileManager ProfileManager { get; }


        public SettingsPopupViewPresenter(ProfileManager profileManager)
            : base("Assets/GameAssets/Home/Prefabs/SettingsPopup.prefab")
        {
            ProfileManager = profileManager;
        }

        public override void InitializeView()
        {
            base.InitializeView();

            SettingsPopupView.Initialize(this, ProfileManager.IsSoundsEnabled, ProfileManager.IsMusicEnabled);
        }

        public void OnMusicToggleChanged(bool value)
        {
            ProfileManager.IsMusicEnabled = value;

            if (ProfileManager.IsMusicEnabled)
            {
                Debug.Log("[SoundController] Music On");
            }
            else
            {
                Debug.Log("[SoundController] Music Off");
            }
        }

        public void OnSoundsToggleChanged(bool value)
        {
            ProfileManager.IsSoundsEnabled = value;

            if (ProfileManager.IsMusicEnabled)
            {
                Debug.Log("[SoundController] Sounds On");
            }
            else
            {
                Debug.Log("[SoundController] Sounds Off");
            }
        }

        public void OpenSupportPopup()
        {
            Debug.Log("[SettingsPopup] Open support popup");
        }
    }
}