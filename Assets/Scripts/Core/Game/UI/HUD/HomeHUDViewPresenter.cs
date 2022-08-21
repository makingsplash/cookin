using Core.Game.Signals;
using Core.UI.Elements;
using Core.UI.Popups;
using Zenject;

namespace Core.Game.UI.HUD
{
    public class HomeHUDViewPresenter : UIViewBasePresenter
    {
        private SignalBus SignalBus { get; }


        public HomeHUDViewPresenter(SignalBus signalBus)
            : base("Assets/Prefabs/Game/HomeHUD.prefab")
        {
            SignalBus = signalBus;
        }

        public void ProcessSettingsWidgetClick()
        {
            SignalBus.Fire(new ShowPopupSignal(typeof(SettingsPopupViewPresenter)));
        }
    }
}