using System.Collections.Generic;
using Core.Game.Play.ECS.Systems;
using Core.Game.Play.ECS.Systems.CleanupSystems;
using Core.Game.Play.ECS.Systems.ExecuteSystems;
using Core.Game.Play.ECS.Systems.InitializeSystems;
using Core.Game.Play.ECS.Systems.ReactiveSystems;
using Entitas;
using Play.ECS.Common;
using UnityEngine;
using Zenject;

namespace Core.Game.Play.Installers
{
    public class PlayEcsInstaller : MonoInstaller
    {
        [SerializeField]
        private List<EntityViewBehaviour> _entityViewBehaviours;


        public override void InstallBindings()
        {
            var contexts = Contexts.sharedInstance;
            BindContexts(contexts);

            BindSystems();

            Container.BindInstance(contexts).WhenInjectedInto<SystemsExecutor>();
            Container.BindInterfacesTo<SystemsExecutor>().AsSingle().NonLazy();
        }

        private void BindContexts(IContexts contexts)
        {
            foreach (var context in contexts.allContexts)
            {
                Container.Bind(context.GetType()).FromInstance(context).AsSingle();
            }
        }

        private void BindSystems()
        {
            BindViewBehaviours();
            BindInitializeViewsSystems();
            BindExecutableSystems();
            BindReactSystems();
            BindCleanupSystems();
        }

        private void BindViewBehaviours()
        {
            Container.BindInstances(_entityViewBehaviours);
        }

        private void BindInitializeViewsSystems()
        {
            Container.BindInterfacesAndSelfTo<InitializeViewBehavioursSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResetFinishedTimerViewsSystem>().AsSingle();
        }

        private void BindExecutableSystems()
        {
            Container.BindInterfacesAndSelfTo<TimerTickSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<TimerUpdateViewSystem>().AsSingle();
        }

        private void BindReactSystems()
        {
            Container.BindInterfacesAndSelfTo<StoreIngredientsIntoContainersSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<UpdateIngredientContainerViewSystem>().AsSingle();
        }

        private void BindCleanupSystems()
        {
            Container.BindInterfacesAndSelfTo<CleanupFinishedTimersSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CleanupProducedIngredientsSystem>().AsSingle();
        }
    }
}