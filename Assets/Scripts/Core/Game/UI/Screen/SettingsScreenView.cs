using Core.UI.Elements.Popup;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game.UI.Popups
{
    public class SettingsScreenView : ScreenView
    {
        public Toggle SoundsToggle;
        public Toggle MusicToggle;
        public Button SupportButton;
        public Button CloseButton;


        public void Initialize(SettingsScreenViewPresenter presenter, bool isSoundsOn, bool isMusicOn)
        {
            base.Initialize(presenter);

            SoundsToggle.isOn = isSoundsOn;
            MusicToggle.isOn = isMusicOn;
        }
    }
}