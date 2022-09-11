using System;
using Core.Consumables;
using Core.Game.Home.UI.BankScreen;
using Core.Game.Signals;
using Core.Game.UI.Screen;
using Core.UI.Elements.Base;
using Zenject;

namespace Core.Game.Home.UI.HUD
{
    public class HomeHUDViewPresenter : ViewPresenterBase, ISignalListener
    {
        private HomeHUDView HomeHUDView => (HomeHUDView) View;

        private SignalBus SignalBus { get; }
        private ConsumablesManager ConsumablesManager { get; }


        public HomeHUDViewPresenter(SignalBus signalBus, ConsumablesManager consumablesManager)
            : base("Assets/GameAssets/Home/Prefabs/HomeHUD.prefab")
        {
            SignalBus = signalBus;
            ConsumablesManager = consumablesManager;
        }

        public override void InitializeView()
        {
            base.InitializeView();

            HomeHUDView.StarsAmount.text = ConsumablesManager.GetConsumableAmount(ConsumableType.Star).ToString();
            HomeHUDView.DiamondsAmount.text = ConsumablesManager.GetConsumableAmount(ConsumableType.Diamond).ToString();

            SignalsSubscribe();

        }

        protected override void BindView()
        {
            HomeHUDView.SettingsButtnon.onClick.AddListener(ProcessSettingsWidgetClick);
            HomeHUDView.BankButton.onClick.AddListener(OpenBankPopup);

            View.OnClose += SignalsUnsubscribe;

            base.BindView();
        }

        public void SignalsSubscribe()
        {
            SignalBus.Subscribe<ConsumableAmountChangedSignal>(OnConsumableAmountChanged);
        }

        public void SignalsUnsubscribe()
        {
            SignalBus.Unsubscribe<ConsumableAmountChangedSignal>(OnConsumableAmountChanged);
        }

        private void OnConsumableAmountChanged(ConsumableAmountChangedSignal signal)
        {
            // temp

            // support consumable list
            // foreach Consumable UpdateConsumablePanelValue

            UpdateConsumablePanelValue(signal.ConsumableType, signal.OldAmount, signal.NewAmount);
        }

        private void ProcessSettingsWidgetClick()
        {
            SignalBus.TryFire(new ShowPopupSignal(typeof(SettingsScreenViewPresenter)));
        }

        private void OpenBankPopup()
        {
            SignalBus.TryFire(new ShowPopupSignal(typeof(BankScreenViewPresenter)));
        }

        private void UpdateConsumablePanelValue(ConsumableType consumableType, int oldAmount, int newAmount)
        {
            switch(consumableType)
            {
                case ConsumableType.Star:
                    HomeHUDView.StarsAmount.text = newAmount.ToString();
                    break;
                case ConsumableType.Diamond:
                    HomeHUDView.DiamondsAmount.text = newAmount.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(consumableType), consumableType, null);
            }
        }
    }
}