using Core.PlayerProfile;
using Core.UI.Elements.Base;
using Core.UI.Elements.Popup;
using UnityEngine;

namespace Core.Game.UI.Popups
{
    public class SettingsPopupViewPresenter : PopupViewPresenter
    {
        private SettingsPopupView SettingsPopupView => (SettingsPopupView) View;
        private ProfileManager ProfileManager { get; }


        public SettingsPopupViewPresenter(ProfileManager profileManager)
            : base("Assets/GameAssets/Shared/Prefabs/SettingsPopup.prefab")
        {
            ProfileManager = profileManager;
        }

        public override void SetupView(UIViewBase viewBase)
        {
            base.SetupView(viewBase);

            SettingsPopupView.MusicToggle.isOn = ProfileManager.IsMusicEnabled;
            SettingsPopupView.CoinsAmount.text = $"Coins: {ProfileManager.Coins.ToString()}";
        }

        public void OnMusicToggleChanged()
        {
            ProfileManager.IsMusicEnabled = !ProfileManager.IsMusicEnabled;

            if (ProfileManager.IsMusicEnabled)
            {
                Debug.Log("[SoundController] Start playing background music");
            }
            else
            {
                Debug.Log("[SoundController] Stop playing background music");
            }
        }
    }
}