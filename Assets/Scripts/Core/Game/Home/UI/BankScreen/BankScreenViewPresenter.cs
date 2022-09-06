using Core.UI.Elements.Screen;
using UnityEngine;

namespace Core.Game.Home.UI.BankScreen
{
    public class BankScreenViewPresenter : ScreenViewPresenter
    {
        private BankScreenView BankScreenView => ScreenView as BankScreenView;

        public BankScreenViewPresenter() : base("Assets/GameAssets/Home/Prefabs/BankScreen.prefab")
        {
        }

        public override void InitializeView()
        {
            BankScreenView.CoinsAmount.text = "999";

            base.InitializeView();
        }

        protected override void BindView()
        {
            base.BindView();

            BankScreenView.BuyButton.onClick.AddListener(GetFreeStars);
        }

        private void GetFreeStars()
        {
            Debug.Log($"[{nameof(BankScreenViewPresenter)}]: Get free stars");
        }
    }
}