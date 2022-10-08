using System.Collections.Generic;
using Core.Game.Play.ECS.Systems;
using Core.Game.Play.ECS.Systems.CleanupSystems;
using Core.Game.Play.ECS.Systems.ExecuteSystems;
using Core.Game.Play.ECS.Systems.InitializeSystems;
using Core.Game.Play.ECS.Systems.ReactiveSystems;
using Entitas;
using Play.ECS;
using UnityEngine;
using Zenject;

namespace Core.Game.Play.Installers
{
    public class PlayEcsInstaller : MonoInstaller
    {
        [Header("Ingredients")]
        [SerializeField]
        private List<IngredientProducerViewBehaviour> _ingredientProducerViewBehaviours;

        [Header("Ingredients")]
        [SerializeField]
        private List<IngredientsContainerViewBehaviour> _ingredientsContainerViewBehaviours;


        [Header("Timers")]
        [SerializeField]
        private List<TimerViewBehaviour> _timerViewBehaviours;


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
            // абстрактный класс View? чтобы можно было сложить все вьюшки в один лист
            // а лист будет лежать прям тут, тут и биндиться в контейнер?
            // если забиндить так вьюшки, при резолве зависимостей в класс будут поступать нужные классы
            // или всё ещё абстрактный?


            BindViewBehaviours();
            BindInitializeViewsSystems();
            BindExecutableSystems();
            BindReactSystems();
            BindCleanupSystems();
        }

        private void BindViewBehaviours()
        {
            Container.BindInstances(_timerViewBehaviours);
            Container.BindInstances(_ingredientProducerViewBehaviours);
            Container.BindInstances(_ingredientsContainerViewBehaviours);
        }

        private void BindInitializeViewsSystems()
        {
            Container.BindInterfacesAndSelfTo<InitializeIngredientProducerViewsSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitializeIngredientContainerViewsSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitializeTimerViewsSystem>().AsSingle();
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