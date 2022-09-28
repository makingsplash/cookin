using Entitas;

namespace Core.Game.Play.ECS.Components
{
    [Game]
    public class IngredientComponent : IComponent
    {
        public IngredientTypes IngredientType;
    }
}