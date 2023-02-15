using System;
using Core.Consumables;
using Core.Game.Context;
using Core.Game.Home.UI.BankScreen;
using Core.Game.Play;
using Core.Game.Play.Installers;
using Core.Game.UI.Screen;
using Core.Signals;
using Core.UI.Elements.Base;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Core.Game.Home.UI.HUD
{
    public class HomeHUDViewPresenter : ViewPresenterBase, ISignalListener
    {
        private SignalBus SignalBus { get; }
        private ConsumablesManager ConsumablesManager { get; }
        private ContextManager ContextManager { get; }

        private HomeHUDView HomeHUDView => (HomeHUDView) View;


        public HomeHUDViewPresenter(SignalBus signalBus, ConsumablesManager consumablesManager, ContextManager contextManager)
            : base("Assets/GameAssets/Home/Prefabs/HomeHUD.prefab")
        {
            SignalBus = signalBus;
            ConsumablesManager = consumablesManager;
            ContextManager = contextManager;
        }

        public override void InitializeView()
        {
            base.InitializeView();

            HomeHUDView.StarsAmount.text = ConsumablesManager.GetConsumableAmount(ConsumableType.Star).ToString();
            HomeHUDView.DiamondsAmount.text = ConsumablesManager.GetConsumableAmount(ConsumableType.Diamond).ToString();
        }

        protected override void BindView()
        {
            SignalsSubscribe();
            View.OnClose += SignalsUnsubscribe;

            HomeHUDView.SettingsButtnon.onClick.AddListener(ProcessSettingsWidgetClick);
            HomeHUDView.BankButton.onClick.AddListener(OpenBankPopup);
            HomeHUDView.PlayButton.onClick.AddListener(EnterPlayContext);

            base.BindView();
        }

        public void SignalsSubscribe()
        {
            SignalBus.Subscribe<ConsumableAmountChangedSignal>(OnConsumableAmountChanged);
            SignalBus.Subscribe<ResetPlayerDataSignal>(OnResetData);
        }

        public void SignalsUnsubscribe()
        {
            SignalBus.Unsubscribe<ConsumableAmountChangedSignal>(OnConsumableAmountChanged);
            SignalBus.Unsubscribe<ResetPlayerDataSignal>(OnResetData);
        }

        private void EnterPlayContext()
        {
            ContextManager.Load<PlayContext>().Forget();
        }

        private void OnConsumableAmountChanged(ConsumableAmountChangedSignal signal)
        {
            // temp

            // support consumable list
            // foreach Consumable UpdateConsumablePanelValue

            UpdateConsumablePanelValue(signal.ConsumableType, signal.NewAmount, signal.OldAmount);
        }

        private void OnResetData()
        {
            foreach (ConsumableType consumableType in (ConsumableType[]) Enum.GetValues(typeof(ConsumableType)))
            {
                UpdateConsumablePanelValue(consumableType, 0);
            }
        }

        private void ProcessSettingsWidgetClick()
        {
            SignalBus.TryFire(new ShowPopupSignal(typeof(SettingsScreenViewPresenter)));
        }

        private void OpenBankPopup()
        {
            SignalBus.TryFire(new ShowPopupSignal(typeof(BankScreenViewPresenter)));
        }

        private void UpdateConsumablePanelValue(ConsumableType consumableType, int newAmount, int oldAmount = 0)
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