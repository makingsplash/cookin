using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Core.Game.Context
{
    public class ContextManager
    {
        private DiContainer Container { get; }
        private SignalBus SignalBus { get; }

        public Context Context { get; private set; }

        public ContextManager(DiContainer container, SignalBus signalBus)
        {
            Container = container;
            SignalBus = signalBus;
        }

        public async UniTask Load<TContext>() where TContext : Context
        {
            Context = Container.Instantiate<TContext>();

            await Addressables.LoadSceneAsync(Context.Scene);

            Container.Inject(Context);

            await Context.Setup();
        }
    }
}