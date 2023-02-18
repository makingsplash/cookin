using System.Collections.Generic;
using Core.Signals;
using Zenject;

namespace Core.Game.Play.Configs
{
    public class LevelDishes
    {
        public readonly List<Dish> LevelDishesToCollect;

        // Блюда которые прямо сейчас заказаны, в дальнейшем можно отдавать только их
        // public List<Dish> OrderedDishes;

        private SignalBus SignalBus { get; }

        public LevelDishes(LevelConfig config, SignalBus signalBus)
        {
            LevelDishesToCollect = new List<Dish>(config.Dishes);
            SignalBus = signalBus;
        }

        public void CompleteDish(Dish dish)
        {
            LevelDishesToCollect.Remove(dish);

            SignalBus.TryFire(new LevelDishesUpdatedSignal());
        }
    }
}