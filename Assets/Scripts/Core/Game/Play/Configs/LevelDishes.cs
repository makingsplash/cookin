using System.Collections.Generic;
using Zenject;

namespace Core.Game.Play.Configs
{
    public class LevelDishes
    {
        public readonly List<Dish> DishesToAssign;
        public readonly Dictionary<GameEntity, Dish> ActiveOrders = new ();

        // Блюда которые прямо сейчас заказаны, в дальнейшем можно отдавать только их
        // public List<Dish> OrderedDishes;

        private SignalBus SignalBus { get; }

        public LevelDishes(LevelConfig config, SignalBus signalBus)
        {
            DishesToAssign = new List<Dish>(config.Dishes);
            SignalBus = signalBus;
        }

        public void CompleteOrder(GameEntity guest)
        {
            ActiveOrders.Remove(guest);
        }
    }
}