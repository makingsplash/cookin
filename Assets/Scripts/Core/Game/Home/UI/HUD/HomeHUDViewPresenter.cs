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
            HomeHUDView.Initialize();
        }

        public void ProcessSettingsWidgetClick()
        {
            SignalBus.TryFire(new ShowPopupSignal(typeof(SettingsPopupViewPresenter)));
        }

        public void OpenBankPopup()
        {
            Debug.Log($"[{typeof(HomeHUDView)}]: Show bank popup");

            // SignalBus.TryFire(new ShowPopupSignal(typeof(BankPopupView)));
        }
    }
}