using Core.UI.Elements.Popup;
using TMPro;
using UnityEngine.UI;

namespace Core.UI.Popups
{
    public class SettingsPopupView : PopupView
    {
        public Toggle MusicToggle;
        public TextMeshProUGUI CoinsAmount;

        private SettingsPopupViewPresenter SettingsPopupViewPresenter => Presenter as SettingsPopupViewPresenter;

        public void OnMusicToggleValueChanged()
        {
            SettingsPopupViewPresenter.OnMusicToggleChanged();
        }
    }
}