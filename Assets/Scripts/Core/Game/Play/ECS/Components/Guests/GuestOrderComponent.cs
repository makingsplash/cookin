using Core.Game.Play.Configs;
using Entitas;

namespace Play.ECS
{
    [Game]
    public class GuestOrderComponent : IComponent
    {
        public Dish Order;
    }
}