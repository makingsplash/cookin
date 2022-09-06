using Core.Game.Home.UI.BankScreen;
using Core.Game.Signals;
using Core.Game.UI.Screen;
using Core.UI.Elements.Base;
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
            base.InitializeView();
        }

        protected override void BindView()
        {
            base.BindView();

            HomeHUDView.SettingsButtnon.onClick.AddListener(ProcessSettingsWidgetClick);
            HomeHUDView.BankButton.onClick.AddListener(OpenBankPopup);
        }

        private void ProcessSettingsWidgetClick()
        {
            SignalBus.TryFire(new ShowPopupSignal(typeof(SettingsScreenViewPresenter)));
        }

        private void OpenBankPopup()
        {
            SignalBus.TryFire(new ShowPopupSignal(typeof(BankScreenViewPresenter)));
        }
    }
}