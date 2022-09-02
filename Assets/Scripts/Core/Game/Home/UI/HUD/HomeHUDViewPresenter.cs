using Core.Game.Signals;
using Core.Game.UI.Popups;
using Core.UI.Elements.Base;
using Zenject;

namespace Core.Game.Home.UI.HUD
{
    public class HomeHUDViewPresenter : UIViewBasePresenter
    {
        private SignalBus SignalBus { get; }


        public HomeHUDViewPresenter(SignalBus signalBus)
            : base("Assets/GameAssets/Home/Prefabs/HomeHUD.prefab")
        {
            SignalBus = signalBus;
        }

        public void ProcessSettingsWidgetClick()
        {
            SignalBus.TryFire(new ShowPopupSignal(typeof(SettingsPopupViewPresenter)));
        }
    }
}