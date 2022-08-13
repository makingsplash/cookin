using Core.UI.Elements.Popup;
using UnityEngine.UI;

namespace Core.UI.Popups
{
    public class SettingsPopupView : PopupView
    {
        public Toggle MusicToggle;

        private SettingsPopupViewPresenter SettingsPopupViewPresenter => Presenter as SettingsPopupViewPresenter;

        public void OnMusicToggleValueChanged()
        {
            SettingsPopupViewPresenter.OnMusicToggleChanged();
        }
    }
}