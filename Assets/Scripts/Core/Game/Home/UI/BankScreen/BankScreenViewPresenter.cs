using Core.Consumables;
using Core.Game.Signals;
using Core.Transactions;
using Core.UI.Elements.Screen;
using Zenject;

namespace Core.Game.Home.UI.BankScreen
{
    public class BankScreenViewPresenter : ScreenViewPresenter
    {

        private SignalBus SignalBus { get; }
        private BankScreenView BankScreenView => ScreenView as BankScreenView;

        public BankScreenViewPresenter(SignalBus signalBus)
            : base("Assets/GameAssets/Home/Prefabs/BankScreen.prefab")
        {
            SignalBus = signalBus;
        }

        public override void InitializeView()
        {
            BankScreenView.CoinsAmount.text = "999";

            base.InitializeView();
        }

        protected override void BindView()
        {
            BankScreenView.BuyButton.onClick.AddListener(GetFreeStars);

            base.BindView();
        }

        private void GetFreeStars()
        {
            var transaction = new Transaction(ConsumableType.Star, 100);

            SignalBus.TryFire(new TransactionSignal(transaction));
        }
    }
}