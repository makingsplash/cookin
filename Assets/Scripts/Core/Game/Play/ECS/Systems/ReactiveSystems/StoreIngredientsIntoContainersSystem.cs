using System.Collections.Generic;
using Entitas;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class StoreIngredientsIntoContainersSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _ingredientContainers;

        public StoreIngredientsIntoContainersSystem(IContext<GameEntity> context) : base(context)
        {
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

        private bool TryAddIngredient(Stack<IngredientTypes> ingredients, IngredientTypes newIngredient)
        {
            if (ingredients.Contains(newIngredient) ||
                ingredients.Count > 0 && ingredients.Peek() == IngredientTypes.UpperBun)
                return false;

            ingredients.Push(newIngredient);

            return true;
        }
    }
}