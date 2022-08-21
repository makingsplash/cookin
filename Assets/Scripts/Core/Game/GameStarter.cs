using Core.Game.Signals;
using Core.Game.UI.HUD;
using Core.Managers;
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
            SignalBus.Fire(new ShowPopupSignal(typeof(HomeHUDViewPresenter)));
        }
    }
}