using System.Collections.Generic;
using System.Linq;
using Core.Game.Play.Configs;
using Entitas;
using Play.ECS;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class CreateOrderForArrivedGuestsSystem : ReactiveSystem<GameEntity>
    {
        private LevelDishes _levelDishes;


        public CreateOrderForArrivedGuestsSystem(GameContext context, LevelDishes levelDishes) : base(context)
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
                Dish dish = _levelDishes.DishesToAssign.First();
                _levelDishes.ActiveOrders.Add(guestEntity, dish);
                _levelDishes.DishesToAssign.Remove(dish);

                guestEntity.AddPlayECSOrderedGuest(dish);
                guestEntity.playECSArrivedGuest.View.SetState(GuestState.Arrived);
            }
        }
    }
}