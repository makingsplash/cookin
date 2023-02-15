using Core.Game.Play.Configs;
using Entitas;

namespace Play.ECS.Dishes
{
    [Game]
    public class CompletedDishComponent : IComponent
    {
        public Dish Dish;
    }
}