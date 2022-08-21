using Core.Managers;
using Zenject;

namespace Core.Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ProfileManager>().AsSingle().NonLazy();
        }
    }
}