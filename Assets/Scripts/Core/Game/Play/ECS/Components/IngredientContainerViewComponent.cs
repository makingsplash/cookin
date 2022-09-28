using System.Collections.Generic;
using Core.Game.Play.ECS.Behaviours;
using Entitas;

namespace Core.Game.Play.ECS.Components
{
    [Game]
    public class IngredientContainerViewComponent : IComponent
    {
        public Stack<IngredientTypes> Ingredients;
        public IngredientsContainerViewBehaviour ViewBehaviour;
    }
}