using System.Collections.Generic;
using Core.Game.Play.Configs;
using Entitas;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class RegisterGuestOrderSystem : ReactiveSystem<GameEntity>
    {
        private LevelDishes _levelDishes;


        public RegisterGuestOrderSystem(GameContext context, LevelDishes levelDishes) : base(context)
        {
            _levelDishes = levelDishes;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.PlayECSArrivedGuest);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPlayECSArrivedGuest;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var guestEntity in entities)
            {
                Dish dish = guestEntity.playECSGuestOrder.Order;
                if (dish.Ingredients.Count > 1)
                {
                    _levelDishes.ActiveMultipleIngredientOrders.Add(guestEntity, dish);
                }
                else
                {
                    _levelDishes.ActiveSingleIngredientOrders.Add(guestEntity, dish);
                }

                guestEntity.AddPlayECSOrderedGuest(dish);
            }
        }
    }
}