using Core.UI.Elements.Popup;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game.UI.Popups
{
    public class SettingsPopupView : PopupView
    {
        [SerializeField]
        private Toggle soundsToggle;
        [SerializeField]
        private Toggle musicToggle;
        [SerializeField]
        private Button supportButton;
        [SerializeField]
        private Button closeButton;

        private SettingsPopupViewPresenter SettingsPopupViewPresenter => Presenter as SettingsPopupViewPresenter;


        public void Initialize(SettingsPopupViewPresenter presenter, bool isSoundsOn, bool isMusicOn)
        {
            base.Initialize(presenter);

            soundsToggle.isOn = isSoundsOn;
            musicToggle.isOn = isMusicOn;

            soundsToggle.onValueChanged.AddListener(SettingsPopupViewPresenter.OnSoundsToggleChanged);
            musicToggle.onValueChanged.AddListener(SettingsPopupViewPresenter.OnMusicToggleChanged);
            supportButton.onClick.AddListener(SettingsPopupViewPresenter.OpenSupportPopup);
            closeButton.onClick.AddListener(Close);
        }
    }
}