using Core.Game.Play.ECS;
using Entitas;

namespace Play.ECS
{
    [Game]
    public class IngredientComponent : IComponent
    {
        public IngredientTypes IngredientType;
    }
}