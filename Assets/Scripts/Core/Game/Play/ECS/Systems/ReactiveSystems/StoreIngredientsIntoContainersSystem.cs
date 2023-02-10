using System.Collections.Generic;
using Core.Game.Play.Configs;
using Entitas;
using UnityEngine;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class StoreIngredientsIntoContainersSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _ingredientContainers;
        private LevelDishesConfig _dishesConfig;
        private List<List<IngredientType>> _possibleIngredientVariations = new ();


        public StoreIngredientsIntoContainersSystem(GameContext context, LevelDishesConfig dishesConfig) : base(context)
        {
            _dishesConfig = dishesConfig;
            FillPossibleIngredientVariations();

            _ingredientContainers =
                context.GetGroup(GameMatcher.PlayECSIngredientContainerView);
        }

        private void FillPossibleIngredientVariations()
        {
            foreach (var dish in _dishesConfig.Dishes)
            {
                for (int i = 0; i < dish.Ingredients.Count; i++)
                {
                    if (_possibleIngredientVariations.Count - 1 < i || !_possibleIngredientVariations[i].Contains(dish.Ingredients[i]))
                    {
                        if (_possibleIngredientVariations.Count - 1 < i)
                        {
                            _possibleIngredientVariations.Add(new List<IngredientType>());
                        }

                        _possibleIngredientVariations[i].Add(dish.Ingredients[i]);
                    }
                }
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
            foreach (var ingredientsContainer in _ingredientContainers)
            {
                foreach (var e in entities)
                {
                    var ingredients = ingredientsContainer.playECSIngredientContainerView.Ingredients;
                    var newIngredient = e.playECSIngredient.IngredientType;

                    TryAddIngredient(ingredients, newIngredient); // return if true
                }
            }
        }

        private bool TryAddIngredient(List<IngredientType> ingredients, IngredientType newIngredient)
        {
            // может быть ситуация когда мы положим булочку сыр сыр
            // хоть это будут допустимые ингридиенты, это не будет рецептурной сборкой

            /*
             * у каждого контейнера есть список доступных ему блюд
             * каждый раз при появлении ингридиента мы проверяем можем ли мы положить ингридиент (свойство NextPossibleIngredient)
             * когда кладём в него ингридиент, уменьшаем список доступных блюд
             */

             /*
              * у каждого контейнера есть DishType который он принимает
              * каждый рецепт в конфиге имеет поле DishType и список ингридиентов
              */

            if (ingredients.Count >= _possibleIngredientVariations.Count)
            {
                Debug.Log("Для этого контейнера больше нет доступных ингредиентов??");
                return false;
            }

            if (!_possibleIngredientVariations[ingredients.Count].Contains(newIngredient))
            {
                Debug.Log("Не подходящий ингредиент для этого контейнера");
                return false;
            }

            ingredients.Add(newIngredient);

            return true;
        }
    }
}