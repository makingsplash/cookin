using Core.Game.Home.UI.HUD;
using Core.Game.Signals;
using Core.UI;
using UnityEngine;
using Zenject;

namespace Core.Game
{
    public class GameStarter : MonoBehaviour
    {
        private UIManager UIManager { get; set; }
        private SignalBus SignalBus { get; set; }

        [Inject]
        private void Inject(UIManager uiManager, SignalBus signalBus)
        {
            UIManager = uiManager;
            SignalBus = signalBus;
        }

        private void Start()
        {
            SignalBus.TryFire(new ShowPopupSignal(typeof(HomeHUDViewPresenter)));
        }
    }
}