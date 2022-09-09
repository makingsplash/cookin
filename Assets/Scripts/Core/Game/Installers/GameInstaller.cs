using Core.Game.Context;
using Core.Game.Signals;
using Core.PlayerProfile;
using Core.Transactions;
using Zenject;

namespace Core.Game.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ProfileManager>().AsSingle();
            Container.Bind<ContextManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<TransactionManager>().AsSingle();

            SignalBusInstaller.Install(Container);
            DeclareSignals();
        }

        private void DeclareSignals()
        {
            Container.DeclareSignal<ShowPopupSignal>();
            Container.DeclareSignal<TransactionSignal>();
            Container.DeclareSignal<ConsumableAmountChangedSignal>();
        }
    }
}