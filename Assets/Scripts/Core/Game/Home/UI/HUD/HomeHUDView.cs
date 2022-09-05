using Core.UI.Elements.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game.Home.UI.HUD
{
    public class HomeHUDView : UIViewBase
    {
        [SerializeField]
        private Button settingsButtnon;
        [SerializeField]
        private Button bankButton;

        private HomeHUDViewPresenter HomeHUDViewPresenter => Presenter as HomeHUDViewPresenter;

        public void Initialize()
        {
            settingsButtnon.onClick.AddListener(HomeHUDViewPresenter.ProcessSettingsWidgetClick);
            bankButton.onClick.AddListener(HomeHUDViewPresenter.OpenBankPopup);
        }
    }
}