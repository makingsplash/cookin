using Core.Game.Play.ECS;
using Entitas;

namespace Play.ECS
{
    [Game]
    public class CollectedIngredientComponent : IComponent
    {
        public IngredientType IngredientType;
    }
}