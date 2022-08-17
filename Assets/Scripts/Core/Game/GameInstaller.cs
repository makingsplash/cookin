using Core.Managers;
using Zenject;

namespace Core.Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SavingsManager>().AsSingle().NonLazy();
        }
    }
}