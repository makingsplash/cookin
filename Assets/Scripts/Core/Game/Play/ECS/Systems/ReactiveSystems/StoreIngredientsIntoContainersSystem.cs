using System.Collections.Generic;
using Core.Game.Play.Configs;
using Entitas;
using Play.ECS;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class StoreIngredientsIntoContainersSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private IGroup<GameEntity> _ingredientContainers;
        private Dish[] _levelDishes;

        private Dictionary<IngredientContainerViewComponent, List<IngredientType>> _containerToPossibleIngredients;


        public StoreIngredientsIntoContainersSystem(GameContext context, LevelConfig config) : base(context)
        {
            _levelDishes = new Dish[config.Dishes.Count];
            config.Dishes.CopyTo(_levelDishes);
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
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.PlayECSIngredient));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPlayECSIngredient;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameEntity producerEntity = entities[0];
            IngredientType ingredient = producerEntity.playECSIngredient.IngredientType;

            if (!producerEntity.hasPlayECSCollectedIngredient)
            {
                foreach (var containerToPossibleIngredient in _containerToPossibleIngredients)
                {
                    if (containerToPossibleIngredient.Value.Contains(producerEntity.playECSIngredient.IngredientType))
                    {
                        IngredientContainerViewComponent container = containerToPossibleIngredient.Key;
                        container.Ingredients.Add(ingredient);
                        UpdatePossibleIngredientsForContainer(container);

                        producerEntity.AddPlayECSCollectedIngredient(ingredient);

                        break;
                    }
                }
            }
        }

        public void UpdatePossibleIngredientsForContainer(IngredientContainerViewComponent container)
        {
            if (!_containerToPossibleIngredients.ContainsKey(container))
            {
                _containerToPossibleIngredients[container] = new List<IngredientType>();

                foreach (var dish in _levelDishes)
                {
                    if (dish.Ingredients.Count > 1 && !_containerToPossibleIngredients[container].Contains(dish.Ingredients[0]))
                    {
                        _containerToPossibleIngredients[container].Add(dish.Ingredients[0]);
                    }
                }
            }
            else
            {
                _containerToPossibleIngredients[container].Clear();

                int containerNextIndex = container.Ingredients.Count;

                foreach (var dish in _levelDishes)
                {
                    if (dish.Ingredients.Count <= containerNextIndex || dish.Ingredients.Count == 1)
                    {
                        continue;
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
        }
    }
}