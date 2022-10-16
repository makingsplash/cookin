using System.Collections.Generic;
using Core.Game.Play.Configs;
using Entitas;
using UnityEngine;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class CollectCompletedDish : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _ingredientContainers;
        private LevelDishesConfig _dishesConfig;

        public CollectCompletedDish(GameContext context, LevelDishesConfig dishesConfig) : base(context)
        {
            _dishesConfig = dishesConfig;

            _ingredientContainers =
                context.GetGroup(GameMatcher.PlayECSIngredientContainerView);
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
            foreach (var container in _ingredientContainers)
            {
                var containerIngredients = container.playECSIngredientContainerView.Ingredients;

                foreach (var dish in _dishesConfig.Dishes)
                {
                    var dishCompleted = true;

                    if (containerIngredients.Count >= dish.Ingredients.Count)
                    {
                        for (int i = 0; i < dish.Ingredients.Count; i++)
                        {
                            if (dish.Ingredients[i] != containerIngredients[i])
                            {
                                dishCompleted = false;
                            }
                        }

                        if (dishCompleted)
                        {
                            Debug.Log("Dish is completed");
                            containerIngredients.Clear();
                            return;
                        }
                    }
                }
            }
        }
    }
}