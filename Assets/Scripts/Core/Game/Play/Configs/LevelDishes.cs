using System.Collections.Generic;
using Zenject;

namespace Core.Game.Play.Configs
{
    public class LevelDishes
    {
        public readonly List<Dish> DishesToAssign;
        public readonly Dictionary<GameEntity, Dish> ActiveSingleIngredientOrders = new ();
        public readonly Dictionary<GameEntity, Dish> ActiveMultipleIngredientOrders = new ();

        private SignalBus SignalBus { get; }

        public LevelDishes(LevelConfig config, SignalBus signalBus)
        {
            DishesToAssign = new List<Dish>(config.Dishes);
            SignalBus = signalBus;
        }

        public void CompleteMultipleIngredientsOrder(GameEntity guest)
        {
            ActiveMultipleIngredientOrders.Remove(guest);
        }

        public void CompleteSingleIngredientsOrder(GameEntity guest)
        {
            ActiveSingleIngredientOrders.Remove(guest);
        }
    }
}