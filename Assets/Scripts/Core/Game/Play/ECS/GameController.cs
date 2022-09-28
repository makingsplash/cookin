using System;
using System.Collections.Generic;
using Core.Game.Play.ECS.Systems.Features;
using Play.ECS;
using UnityEngine;

namespace Core.Game.Play.ECS
{
    public class GameController : MonoBehaviour
    {
        public List<IngredientProducerViewBehaviour> IngredientProducerViews;
        public List<IngredientsContainerViewBehaviour> IngredientsContainerViews;

        private Entitas.Systems _systems;

        private void Start()
        {
            var contexts = Contexts.sharedInstance;

            _systems = new Feature("Systems")
                .Add(new GameSystems(contexts, IngredientProducerViews, IngredientsContainerViews));

            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        private void OnDisable()
        {
            Contexts.sharedInstance.Reset();
        }
    }
}