using System.Collections.Generic;
using Core.Game.Play.Configs;
using Entitas;
using Play.ECS;
using UnityEngine;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class StoreIngredientsIntoContainersSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private IGroup<GameEntity> _ingredientContainers;
        private LevelDishesConfig _dishesConfig;

        private Dictionary<IngredientContainerViewComponent, List<IngredientType>> _containerToPossibleIngredients;


        public StoreIngredientsIntoContainersSystem(GameContext context, LevelDishesConfig dishesConfig) : base(context)
        {
            _dishesConfig = dishesConfig;
            _ingredientContainers = context.GetGroup(GameMatcher.PlayECSIngredientContainerView);
        }

        public void Initialize()
        {
            _containerToPossibleIngredients = new Dictionary<IngredientContainerViewComponent, List<IngredientType>>();

            foreach(var container in _ingredientContainers)
            {
                UpdatePossibleIngredientsForContainer(container.playECSIngredientContainerView);
            }
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.PlayECSIngredient);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPlayECSIngredient;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var containerToPossibleIngredient in _containerToPossibleIngredients)
            {
                IngredientType ingredient = entities[0].playECSIngredient.IngredientType;
                if (containerToPossibleIngredient.Value.Contains(entities[0].playECSIngredient.IngredientType))
                {
                    IngredientContainerViewComponent container = containerToPossibleIngredient.Key;

                    container.Ingredients.Add(ingredient);
                    container.View.UpdateView();

                    UpdatePossibleIngredientsForContainer(container);

                    entities[0].AddPlayECSCollectedIngredient(ingredient);

                    break;
                }
            }
        }

        private void UpdatePossibleIngredientsForContainer(IngredientContainerViewComponent container)
        {
            if (!_containerToPossibleIngredients.ContainsKey(container))
            {
                _containerToPossibleIngredients[container] = new List<IngredientType>();

                foreach (var dish in _dishesConfig.Dishes)
                {
                    if (!_containerToPossibleIngredients[container].Contains(dish.Ingredients[0]))
                    {
                        _containerToPossibleIngredients[container].Add(dish.Ingredients[0]);
                    }
                }
            }
            else
            {
                _containerToPossibleIngredients[container].Clear();

                int containerNextIndex = container.Ingredients.Count;

                foreach (var dish in _dishesConfig.Dishes)
                {
                    if (dish.Ingredients.Count <= containerNextIndex)
                    {
                        break;
                    }

                    bool result = true;
                    for (int i = 0; i < containerNextIndex; i++)
                    {
                        if (dish.Ingredients[i] != container.Ingredients[i])
                        {
                            result = false;
                            break;;
                        }
                    }

                    if (result)
                    {
                        _containerToPossibleIngredients[container].Add(dish.Ingredients[containerNextIndex]);
                    }
                }
            }

            Debug.Log("Container next ingr: " + string.Join(", ", _containerToPossibleIngredients[container]));
        }
    }
}