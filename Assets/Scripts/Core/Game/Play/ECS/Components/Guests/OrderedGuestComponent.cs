using Core.Game.Play.Configs;
using Entitas;

namespace Play.ECS
{
    [Game]
    public class OrderedGuestComponent : IComponent
    {
        public Dish Order;
        // timeMax
        // timeLeft (tickable with execute system)
    }
}