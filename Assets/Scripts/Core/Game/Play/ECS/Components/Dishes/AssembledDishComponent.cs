using Core.Game.Play.Configs;
using Entitas;

namespace Play.ECS.Dishes
{
    [Game]
    public class AssembledDishComponent : IComponent
    {
        public Dish Dish;
    }
}