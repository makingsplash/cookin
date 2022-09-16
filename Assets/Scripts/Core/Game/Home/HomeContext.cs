using Core.Game.Home.UI.HUD;
using Core.Signals;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.Game.Home
{
    public class HomeContext : Core.Context.IContext
    {
        public string Scene => "Assets/GameAssets/Home/Scenes/HomeScene.unity";

        private SignalBus SignalBus { get; }

        public HomeContext(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        public UniTask Setup()
        {
            Debug.Log($"[{nameof(HomeContext)}]: Setup");

            // use UIManager manually, await for creation
            SignalBus.TryFire(new ShowPopupSignal(typeof(HomeHUDViewPresenter)));

            return new UniTask();
        }
    }
}