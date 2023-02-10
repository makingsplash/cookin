using System.Collections.Generic;
using Core.Game.Play.ECS;
using Entitas;

namespace Play.ECS
{
    [Game]
    public class IngredientContainerViewComponent : IComponent
    {
        public IngredientsContainerViewBehaviour View;
        public List<IngredientType> Ingredients;
    }
}