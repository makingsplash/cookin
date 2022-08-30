using Core.Game.Home.UI.HUD;
using Core.Game.Signals;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Core.Game.Context
{
    public class ContextManager
    {
        private DiContainer Container { get; }
        private SignalBus SignalBus { get; }

        public ContextManager(DiContainer container, SignalBus signalBus)
        {
            Container = container;
            SignalBus = signalBus;
        }

        public async UniTask Load<TContext>() where TContext : Context
        {
            Context context = Container.Instantiate<TContext>();

            await Addressables.LoadSceneAsync(context.Scene);

            // Use method, await creation?
            SignalBus.TryFire(new ShowPopupSignal(typeof(HomeHUDViewPresenter)));
        }
    }
}