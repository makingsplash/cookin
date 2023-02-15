using Core.Game.Play.Configs;
using Entitas;

namespace Play.ECS.Dishes
{
    [Game]
    public class CollectedDishComponent : IComponent
    {
        public Dish Dish;
    }
}