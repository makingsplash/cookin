using Core.Game.Context;
using Core.Game.Signals;
using Core.PlayerProfile;
using Zenject;

namespace Core.Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ProfileManager>().AsSingle().NonLazy();
            Container.Bind<ContextManager>().AsSingle().NonLazy();

            SignalBusInstaller.Install(Container);
            InstallSignals();
        }

        private void InstallSignals()
        {
            Container.DeclareSignal<ShowPopupSignal>();
        }
    }
}