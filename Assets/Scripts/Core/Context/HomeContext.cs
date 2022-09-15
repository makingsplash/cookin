using Core.Game.Home.UI.HUD;
using Core.Game.Signals;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.Game.Context
{
    public class HomeContext : Context
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