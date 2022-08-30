using Core.UI;
using Core.UI.Camera;
using Core.UI.Elements;
using Zenject;

namespace Core.Game
{
    public class GameSceneInstaller : MonoInstaller
    {
        public UICamera UICamera;
        public UIRoot UIRoot;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UICamera>().FromInstance(UICamera).AsSingle().NonLazy();
            Container.Bind<UIRoot>().FromInstance(UIRoot).AsSingle();
            Container.BindInterfacesAndSelfTo<UIManager>().AsSingle().NonLazy();
        }
    }
}