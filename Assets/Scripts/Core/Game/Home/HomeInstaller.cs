using Core.Managers;
using Core.UI.Camera;
using UnityEngine;
using Zenject;

namespace Core.Game.Home
{
    public class HomeInstaller : MonoInstaller
    {
        public UICamera UICamera;
        public UIHandler UIHandler;
        public GameObject GameStarter;


        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UICamera>().FromInstance(UICamera).AsSingle().NonLazy();
            Container.Bind<UIHandler>().FromInstance(UIHandler).AsSingle().NonLazy();
            Container.Bind<UIManager>().AsSingle().NonLazy();
        }

        public override void Start()
        {
            Container.InstantiatePrefabForComponent<GameStarter>(GameStarter);
        }
    }
}