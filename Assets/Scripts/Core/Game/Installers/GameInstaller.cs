using Core.Consumables;
using Core.Game.Context;
using Core.Game.Savings;
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
            InstallSavings();

            Container.Bind<ContextManager>().AsSingle().NonLazy();
            Container.Bind<ConsumablesManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<TransactionManager>().AsSingle();

            SignalBusInstaller.Install(Container);
            DeclareSignals();
        }

        private void InstallSavings()
        {
            Container.Bind<JsonDataManager>().AsSingle();
            Container.Bind<SavingsManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ProfileManager>().AsSingle().NonLazy();
        }

        private void DeclareSignals()
        {
            Container.DeclareSignal<ShowPopupSignal>();
            Container.DeclareSignal<TransactionSignal>();
            Container.DeclareSignal<ConsumableAmountChangedSignal>();
        }
    }
}