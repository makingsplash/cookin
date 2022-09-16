using Core.Game.Home.UI.HUD;
using Core.Signals;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.Context
{
    public class HomeContext : Game.Context.Context
    {
        public override string Scene => "Assets/GameAssets/Home/Scenes/HomeScene.unity";

        public SignalBus SignalBus { get; }

        public HomeContext(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        public override UniTask Setup()
        {
            Debug.Log($"[{nameof(HomeContext)}]: Setup");

            SignalBus.TryFire(new ShowPopupSignal(typeof(HomeHUDViewPresenter)));

            return base.Setup();
        }
    }
}