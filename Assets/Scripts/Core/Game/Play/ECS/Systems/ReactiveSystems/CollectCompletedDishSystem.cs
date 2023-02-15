using System.Collections.Generic;
using Core.Game.Play.Configs;
using Entitas;
using UnityEngine;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class CollectCompletedDishSystem : ReactiveSystem<GameEntity>
    {
        private List<Dish> _levelDishes;

        public CollectCompletedDishSystem(GameContext context, LevelDishesConfig dishesConfig) : base(context)
        {
            _levelDishes = new List<Dish>(dishesConfig.Dishes);

            DebugPrint();
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.PlayECSDishesCompletedDish);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPlayECSDishesCompletedDish;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Dish completedDish = entities[0].playECSDishesCompletedDish.Dish;

            for (int i = 0; i < _levelDishes.Count; i++)
            {
                Dish requiredDish = _levelDishes[i];

                if (requiredDish.Ingredients.Count != completedDish.Ingredients.Count)
                {
                    continue;
                }

                bool validDish = true;
                for (int j = 0; j < requiredDish.Ingredients.Count; j++)
                {
                    if (requiredDish.Ingredients[j] != completedDish.Ingredients[j])
                    {
                        validDish = false;

                        break;
                    }
                }

                if (validDish)
                {
                    entities[0].AddPlayECSDishesCollectedDish(completedDish);
                    _levelDishes.RemoveAt(i);

                    DebugPrint();

                    break;
                }
            }
        }

        private void DebugPrint()
        {
            Debug.LogWarning("<<< Required dishes");
            foreach (var dish in _levelDishes)
            {
                Debug.LogWarning(string.Join(", ", dish.Ingredients));
            }
            Debug.LogWarning(">>>");
        }
    }
}