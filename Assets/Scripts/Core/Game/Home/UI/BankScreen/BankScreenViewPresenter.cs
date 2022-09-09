using Core.Game.Home.Configs;
using Core.Game.Signals;
using Core.PlayerProfile;
using Core.Transactions;
using Core.UI.Elements.Screen;
using UnityEngine;
using Zenject;

namespace Core.Game.Home.UI.BankScreen
{
    public class BankScreenViewPresenter : ScreenViewPresenter
    {
        private SignalBus SignalBus { get; }
        private BankConfig BankConfig { get; }
        private ProfileManager ProfileManager {get; }
        private BankScreenView BankScreenView => ScreenView as BankScreenView;

        public BankScreenViewPresenter(SignalBus signalBus, BankConfig bankConfig, ProfileManager profileManager)
            : base("Assets/GameAssets/Home/Prefabs/BankScreen/BankScreen.prefab")
        {
            SignalBus = signalBus;
            BankConfig = bankConfig;
            ProfileManager = profileManager;
        }

        public override void InitializeView()
        {
            InitializeBankItems();

            base.InitializeView();
        }

        private void InitializeBankItems()
        {
            for (var i = 0; i < BankConfig.BankItems.Count; i++)
            {
                BankItem bankItemView = BankScreenView.BankItems[i];
                BankConfigItem bankItemConfig = BankConfig.BankItems[i];

                bankItemView.ProductAmount.text = bankItemConfig.ProductAmount.ToString();
                bankItemView.PriceAmount.text = bankItemConfig.Free ? "Free" : BankConfig.BankItems[i].PriceAmount.ToString();

                int bankItemIndex = i;
                bankItemView.BuyButton.onClick.AddListener(() => OnBuyButtonClicked(bankItemIndex));
            }
        }

        private void OnBuyButtonClicked(int bankItemIndex)
        {
            BankConfigItem bankConfigItem = BankConfig.BankItems[bankItemIndex];

            if (!bankConfigItem.Free)
            {
                if(ProfileManager.GetConsumableAmount(bankConfigItem.PriceConsumableType) >= bankConfigItem.PriceAmount)
                {
                    Transaction transactionPurchase = new Transaction(bankConfigItem.PriceConsumableType, -bankConfigItem.PriceAmount);
                    SignalBus.TryFire(new TransactionSignal(transactionPurchase));
                }
                else
                {
                    Debug.Log($"[{nameof(BankScreenViewPresenter)}]: Not enough {bankConfigItem.PriceConsumableType}s to make purchase");

                    return;
                }
            }

            Transaction transactionProduct = new Transaction(bankConfigItem.ProductConsumableType, bankConfigItem.ProductAmount);
            SignalBus.TryFire(new TransactionSignal(transactionProduct));
        }
    }
}