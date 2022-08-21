using Core.Managers;
using Core.UI.Camera;
using UnityEngine;
using Zenject;

namespace Core.Game.Home
{
    public class HomeInstaller : MonoInstaller
    {
        public UICamera UICamera;
        public UIRoot uiRoot;
        public GameObject GameStarter;


        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UICamera>().FromInstance(UICamera).AsSingle().NonLazy();
            Container.Bind<UIRoot>().FromInstance(uiRoot).AsSingle().NonLazy();
            Container.Bind<UIManager>().AsSingle().NonLazy();
        }

        public override void Start()
        {
            Container.InstantiatePrefabForComponent<GameStarter>(GameStarter);
        }
    }
}