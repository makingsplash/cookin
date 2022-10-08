using Core.Game.Play.UI.HUD;
using Core.Signals;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.Game.Play.Installers
{
    public class PlayContext : Core.Context.IContext
    {
        public string Scene => "Assets/GameAssets/Play/Scenes/PlayScene.unity";

        private SignalBus SignalBus { get; }

        public PlayContext(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        public UniTask Setup()
        {
            Debug.Log($"[{nameof(PlayContext)}]: Setup");

            // use UIManager manually, await for creation
            SignalBus.TryFire(new ShowPopupSignal(typeof(PlayHUDViewPresenter)));

            return new UniTask();
        }
    }
}