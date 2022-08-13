using Core.Managers;
using Core.UI.Elements;
using Core.UI.Elements.Popup;
using UnityEngine;

namespace Core.UI.Popups
{
    public class SettingsPopupViewPresenter : PopupViewPresenter
    {
        private SettingsPopupView SettingsPopupView => (SettingsPopupView) View;
        private SavingsManager SavingsManager { get; }


        // Inject
        public SettingsPopupViewPresenter(SavingsManager savingsManager)
            : base("Assets/Prefabs/Core/UI/SettingsPopup.prefab")
        {
            SavingsManager = savingsManager;
        }

        public override void SetupView(UIViewBase viewBase)
        {
            base.SetupView(viewBase);

            SettingsPopupView.MusicToggle.isOn = SavingsManager.IsMusicEnabled;
        }

        public void OnMusicToggleChanged()
        {
            SavingsManager.IsMusicEnabled = !SavingsManager.IsMusicEnabled;

            if (SavingsManager.IsMusicEnabled)
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