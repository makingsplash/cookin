using Core.Game.Signals;
using Core.Game.UI.Popups;
using Core.UI.Elements.Base;
using UnityEngine;
using Zenject;

namespace Core.Game.Home.UI.HUD
{
    public class HomeHUDViewPresenter : UIViewBasePresenter
    {
        private HomeHUDView HomeHUDView => (HomeHUDView) View;
        private SignalBus SignalBus { get; }


        public HomeHUDViewPresenter(SignalBus signalBus)
            : base("Assets/GameAssets/Home/Prefabs/HomeHUD.prefab")
        {
            SignalBus = signalBus;
        }

        public override void InitializeView()
        {
            HomeHUDView.SettingsButtnon.onClick.AddListener(ProcessSettingsWidgetClick);
            HomeHUDView.BankButton.onClick.AddListener(OpenBankPopup);
        }

        private void ProcessSettingsWidgetClick()
        {
            SignalBus.TryFire(new ShowPopupSignal(typeof(SettingsScreenViewPresenter)));
        }

        private void OpenBankPopup()
        {
            Debug.Log($"[{nameof(HomeHUDView)}]: Show bank popup");

            // SignalBus.TryFire(new ShowPopupSignal(typeof(BankPopupView)));
        }
    }
}