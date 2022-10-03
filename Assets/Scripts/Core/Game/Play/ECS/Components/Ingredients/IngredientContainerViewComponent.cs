using System.Collections.Generic;
using Core.Game.Play.ECS;
using Entitas;

namespace Play.ECS
{
    [Game]
    public class IngredientContainerViewComponent : IComponent
    {
        public IngredientsContainerViewBehaviourBehaviour View;
        public Stack<IngredientTypes> Ingredients;
    }
}