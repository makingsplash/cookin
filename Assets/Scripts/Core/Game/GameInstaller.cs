using Core.Game.Signals;
using Core.Managers;
using Zenject;

namespace Core.Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ProfileManager>().AsSingle().NonLazy();

            SignalBusInstaller.Install(Container);
            DeclareSignals();
        }

        private void DeclareSignals()
        {
            Container.DeclareSignal<ShowPopupSignal>();
        }
    }
}